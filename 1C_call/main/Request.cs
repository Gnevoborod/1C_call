using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    internal class Request
    {
        public string Authorisation { get; set; }
        public string AuthData { get; set; }//here set login and pass

        public string RequestBody { get; set; }
    }
}
