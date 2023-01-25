using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    /// <summary>
    /// We can call different methods on host
    /// </summary>
    [Serializable]
    internal class Method :RemoteObject
    {
        public string HttpMethod { get; set; }
        public Method(string name, string link, string httpMethod) : base(name, link)
        {
            HttpMethod = httpMethod;
        }
    }
}
