using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    internal class RemoteObject
    {
        public string Name { get; set; }
        public string Link { get; set; }

        public RemoteObject(string name, string link)
        {
            Name = name;
            Link = link;
        }
    }
}
