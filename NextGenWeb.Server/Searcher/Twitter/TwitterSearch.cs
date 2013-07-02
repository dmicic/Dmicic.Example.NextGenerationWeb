using NextGenWeb.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Searcher.Twitter
{
    [Obsolete("Twitter changed the API. New version requires authentication.")]
    internal class TwitterSearch : ISearchProvider
    {
        public async Task<ResultSet> Search(string term)
        {
            return new ResultSet(new List<ResultItem> 
            {
                new ResultItem() 
                { 
                    Content = "Twitter changed the API. New version requires authentication.", 
                    Title = "No result!", 
                    Url = "https://dev.twitter.com/blog/changes-coming-to-twitter-api" }
            }, 
            ResultSet.EProvider.Twitter);
            
            #region Obsolete code
            /*var client = new RestClient("http://search.twitter.com/");
            var request = new RestRequest("search.json", Method.GET);
            request.AddParameter("q", term.Trim());

            return await Task.Run<ResultSet>(() => 
            {
                var response = client.Execute<TwitterSearchResponse>(request);
                var results = response.Data;
                var items = new List<ResultItem>();

                foreach (var tweet in results.results)
                    items.Add(new ResultItem() { Url = tweet.source, Title = tweet.from_user, Content = tweet.text });

                return new ResultSet(items, ResultSet.EProvider.Twitter);            
            });
            */
            #endregion
        }
    }
}
