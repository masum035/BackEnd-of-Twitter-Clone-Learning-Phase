using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace TweeterBackend.SignalR
{
    public class PresenceHub : Hub
    {
        public static int TotalView { get; set; } = 0;
        public override async Task OnConnectedAsync()
        {
            // if (Context.User != null) await Clients.Others.SendAsync("UserIsOnline", Context.User.Identity);
            TotalView++;
            await Clients.Others.SendAsync("TotalViewCount", TotalView);

        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            if (Context.User != null) await Clients.Others.SendAsync("UserIsOffline", Context.User.Identity);
            await base.OnDisconnectedAsync(exception);
        }
    }
}