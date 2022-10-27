using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TweeterBackend.installer
{
    public static class InstallerExtions
    {
        public static void InstallerServicesAssemly(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x => typeof(I_installer).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(Activator.CreateInstance).Cast<I_installer>().ToList();

            installers.ForEach(installer => installer.InstallerService(services, Configuration));

        }
    }
}
