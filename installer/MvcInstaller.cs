using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TweeterBackend.installer
{
    public class MvcInstaller : I_installer
    {

        void I_installer.InstallerService(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllersWithViews(); // for MVC

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo { Title = "Tweeter Api", Version = "v1" });
            });
        }
    }
}
