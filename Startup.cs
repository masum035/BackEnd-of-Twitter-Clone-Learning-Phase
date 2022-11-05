using System;
using System.IO;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using TweeterBackend.installer;
using TweeterBackend.Middlewares;
using TweeterBackend.Models;
using TweeterBackend.Options;

namespace TweeterBackend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            // LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallerServicesAssemly(Configuration); // clean architecture achieved from Installer Folder
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                // HTTP Strict Transport Security Protocol (HSTS)
            }

            var swaggerOption = new SwaggerOptions();
            Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOption);

            app.UseSwagger(options => { options.RouteTemplate = swaggerOption.JsonRoute; });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerOption.UiEndpoint, swaggerOption.Description);
            });

            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        // logger.LogError($"Something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = $"Internal Server Error.\nTo resolve issue, check the log file."
                        }.ToString());
                    }
                });
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/hello/{name:alpha:minlength(3)?}", async context =>
                {
                    var name = context.GetRouteValue("name");
                    await context.Response.WriteAsync($"just testing routing endpoint\nHello {name}");
                });

                endpoints.MapGet("/custom/{name:CustomConstraintTest}", async context =>
                {
                    var name = context.GetRouteValue("name");
                    await context.Response.WriteAsync($"From Custom routing endpoint\nHello {name}");
                });

                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
