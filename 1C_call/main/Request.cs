using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    internal class Request
    {
        public Host host;
        public Method method;
        public string AuthorisationType { get; set; }
        public string AuthData { get; set; }//here set login and pass

        public string RequestBody { get; set; }

        public Request(Host host, Method method, string authData, string requestBody, string authorisationType="Basic")
        {
            this.host = host;
            this.method = method;
            AuthorisationType = authorisationType;
            AuthData = authData;
            RequestBody = requestBody;
        }
    }
}
