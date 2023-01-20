using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    internal class Caller
    {
        Host host;
        Method method;
        Request request;
        Response response;

        public Caller(Host host, Method method)
        {
            this.host = host;
            this.method = method;
        }

        /// <summary>
        /// make a call and save Respnonse
        /// </summary>
        /// <returns></returns>
        public bool Call()
        {
            return true;
        }
         
    }
}
