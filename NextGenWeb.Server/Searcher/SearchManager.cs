using NextGenWeb.Entity;
using NextGenWeb.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Searcher
{
    public static class SearchManager
    {
        public static void SearchAsync(SearchForCommand command, Action<Task<ResultSet>> callback)
        {
            var google = Searcher.SearchFactory.Get(Entity.ResultSet.EProvider.Google);
            var twitter = Searcher.SearchFactory.Get(Entity.ResultSet.EProvider.Twitter);

            Console.WriteLine(string.Empty);
            Console.WriteLine("Search for: " + command.Term);

            var awaitGoogle = google.Search(command.Term);
            var awaitTwitter = twitter.Search(command.Term);

            awaitGoogle.ContinueWith(callback);
            awaitTwitter.ContinueWith(callback);
        }
    }
}
