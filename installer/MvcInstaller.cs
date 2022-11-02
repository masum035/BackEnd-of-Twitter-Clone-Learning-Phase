using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TweeterBackend.Options;

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
                options.ConstraintMap.Add("CustomConstraintTest",typeof(CustomRoutingConstraint));
            });
            services.AddControllersWithViews(); // for MVC

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweeter Api", Version = "v1" });
            });
        }
    }
}
