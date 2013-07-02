using NextGenWeb.Server.Searcher.Google;
using NextGenWeb.Server.Searcher.Twitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Searcher
{
    public static class SearchFactory
    {
        public static ISearchProvider Get(Entity.ResultSet.EProvider provider)
        {
            if (provider == Entity.ResultSet.EProvider.Google)
                return new GoogleSearch();
            return new TwitterSearch();
        }
    }
}
