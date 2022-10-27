using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TweeterBackend.installer
{
    public interface I_installer
    {
        void InstallerService(IServiceCollection services, IConfiguration Configuration);
    }
}
