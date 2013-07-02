using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using NextGenWeb.Message;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NextGenWeb.UI.Hubs
{
    public class SearchResultHub : Hub, IHandleMessages<SearchExecutionEvent>
    {
        public override Task OnConnected()
        {
            if (base.Context.QueryString.AllKeys.Contains("provider"))
            {
                var group = this.GetGroupName(base.Context.QueryString["provider"]);

                if (group != null)
                    base.Groups.Add(base.Context.ConnectionId, group);

            }
            return base.OnConnected();
        }

        public void Handle(SearchExecutionEvent message)
        {
            var hub = this.GetHub<SearchResultHub>();
            
            foreach (var x in message.Result.Items)
            {
                x.Content = HttpUtility.HtmlDecode(x.Content);
                x.Title = HttpUtility.HtmlDecode(x.Title);
                x.Url = HttpUtility.HtmlDecode(x.Url);
            }

            hub.Clients.Group(this.GetGroupName(message.Result.Provider)).showResult(message.Result);
        }

        private string GetGroupName(string provider)
        {
            foreach (var name in Enum.GetNames(typeof(Entity.ResultSet.EProvider)))
                if (name.ToLower() == provider.ToLower())
                    return name.ToLower();
            return null;
        }

        private string GetGroupName(Entity.ResultSet.EProvider provider)
        {
            return Enum.GetName(typeof(Entity.ResultSet.EProvider), provider).ToLower();
        }
    }
}