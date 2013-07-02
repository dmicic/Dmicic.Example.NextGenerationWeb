using NextGenWeb.Entity;
using NextGenWeb.Message;
using NextGenWeb.Server.Searcher;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Handler
{
    public class SearchTermCommandHandler : IHandleMessages<SearchForCommand>
    {
        private IBus Bus { get; set; }

        public SearchTermCommandHandler(IBus bus)
        {
            this.Bus = bus;
        }

        public void Handle(SearchForCommand message)
        {
            SearchManager.SearchAsync(message,
                new Action<Task<ResultSet>>(x =>
                {
                    Console.WriteLine(
                        string.Format("{0} result: {1}",
                        x.Result.Provider == ResultSet.EProvider.Google ? "Google" : "Twitter",
                        x.Result.Count));

                    this.Bus.Publish(new Message.SearchExecutionEvent() { Result = x.Result });
                }));
        }
    }
}
