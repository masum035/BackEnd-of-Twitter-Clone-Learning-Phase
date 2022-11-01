using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TweeterBackend.Middlewares;

namespace TweeterBackend.installer
{
    public class MvcInstaller : IInstaller
    {

        void IInstaller.InstallerService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews(); // for MVC

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweeter Api", Version = "v1" });
            });
        }
    }
}
