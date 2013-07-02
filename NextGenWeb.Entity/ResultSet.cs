using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Entity
{
    public class ResultSet
    {
        public enum EProvider
        { 
            Google = 0,
            Twitter = 1
        }

        public IEnumerable<ResultItem> Items { get; set; }
        public int Count { get { return this.Items.Count(); } }
        public EProvider Provider { get; set; }

        public ResultSet(IEnumerable<ResultItem> items, EProvider provider)
        {
            this.Items = items;
            this.Provider = provider;
        }

        public ResultSet() { }
    }
}
