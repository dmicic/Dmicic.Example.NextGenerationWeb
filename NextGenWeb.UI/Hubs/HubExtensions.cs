using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NextGenWeb.UI.Hubs
{
    public static class HubExtensions
    {
        public static IHubContext GetHub<THub>(this Hub self) where THub : IHub
        {
            return GlobalHost.ConnectionManager.GetHubContext<THub>();
        }
    }
}