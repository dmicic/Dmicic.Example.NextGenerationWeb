using NextGenWeb.Entity;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Message
{
    public class SearchExecutionEvent : IEvent
    {
        public ResultSet Result { get; set; }
    }
}
