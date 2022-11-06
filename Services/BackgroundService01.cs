using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TweeterBackend.Services
{
    public class BackgroundService01 : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                Console.WriteLine("Background Service 01 started");
                await Task.Delay(TimeSpan.FromSeconds(3), stoppingToken);
            }

        }
    }
}
