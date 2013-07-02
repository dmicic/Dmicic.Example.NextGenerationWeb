using Gapi.Search;
using NextGenWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Searcher.Google
{
    public class GoogleSearch : ISearchProvider
    {
        public async Task<ResultSet> Search(string term)
        {
            return await Task.Run<ResultSet>(() =>
            {
                var result = Gapi.Search.Searcher.Search(SearchType.Web, term);
                var items = new List<ResultItem>();

                foreach (var item in result.Items)
                    items.Add(new ResultItem() { Title = item.Title, Url = item.Url, Content = item.Content });

                return new ResultSet(items, ResultSet.EProvider.Google);
            });
        }
    }
}
