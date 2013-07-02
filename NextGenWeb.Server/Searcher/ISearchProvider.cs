using NextGenWeb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Server.Searcher
{
    public interface ISearchProvider
    {
        Task<ResultSet> Search(string term);
    }
}
