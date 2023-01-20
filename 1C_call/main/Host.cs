using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    /// <summary>
    /// Description of host class.
    /// We can call test host or prod host
    /// </summary>
    internal class Host : RemoteObject
    {
        public Host(string name, string link):base(name, link){}
    }
}
