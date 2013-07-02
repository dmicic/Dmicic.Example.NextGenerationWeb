using NServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextGenWeb.Message
{
    public class SearchForCommand : ICommand
    {
        public string Term { get; set; }
    }
}
