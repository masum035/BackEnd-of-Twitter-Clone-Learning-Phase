using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Polly;
using System;
using System.Net.Http;
using TweeterBackend.Contracts.v1;
using TweeterBackend.Filters;
using TweeterBackend.Options;
using TweeterBackend.Services;

namespace TweeterBackend.installer
{
    public class MvcInstaller : IInstaller
    {
        public readonly string MyAllowSpecificOrigins = "Version01_CORS_Policy";

        void IInstaller.InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:5001",
                            "https://localhost:5341");
                    });
            });

            // services.AddResponseCaching();
            services.AddRouting(options =>
            {
                options.ConstraintMap.Add("CustomConstraintTest", typeof(CustomRoutingConstraint));
            });

            // services.AddHttpClient();
            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(5));
            // Named Client
            services.AddHttpClient("weather",
                    client => { client.BaseAddress = new Uri("http://api.weatherapi.com/v1/astronomy.json"); })
                .AddTransientHttpErrorPolicy(policy => policy.WaitAndRetryAsync(3, _ => TimeSpan.FromSeconds(2)))
                .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(3)))
                .AddPolicyHandler(request =>
                {
                    if (request.Method == HttpMethod.Get)
                    {
                        return timeout;
                    }

                    return Policy.NoOpAsync<HttpResponseMessage>();
                });

            services.Configure<WeatherApiOptions>(configuration.GetSection(WeatherApiOptions.WeatherApiInApsSettings));

            services.AddSingleton<ILoggerManager, LoggerManager>();

            services.AddHostedService<BackgroundService01>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new GlobalActionFilter());
            }); // for MVC with global Filters

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweeter Api", Version = "v1" });
            });
        }
    }
}