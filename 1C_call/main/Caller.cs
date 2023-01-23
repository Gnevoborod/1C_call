using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1C_call.main
{
    internal class Caller
    {
        
        Request request;
        Response response;

        public Caller(Request request)
        {
            this.request = request;
        }

        /// <summary>
        /// make a call and save Respnonse
        /// </summary>
        /// <returns></returns>
        public Response[] Call()
        {
            Task<HttpResponseMessage> httpResponseMessage=null;
            HttpRequestMessage httpRequestMessage;
            string responseString=null;
            try
            {
                HttpMethod httpMeth = request.method.HttpMethod == "POST" ?
                    HttpMethod.Post : request.method.HttpMethod == "PUT" ? HttpMethod.Put : HttpMethod.Get;
                var httpClientHandler = new HttpClientHandler();
                httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                HttpClient client = new HttpClient(httpClientHandler);
                httpRequestMessage = new HttpRequestMessage(httpMeth, request.host.Link+request.method.Link);
                httpRequestMessage.Content = new StringContent(request.RequestBody, Encoding.UTF8, "application/json");
                httpRequestMessage.Headers.Add("Authorization", request.AuthorisationType + " " + request.AuthData);
               
                httpResponseMessage = client.SendAsync(httpRequestMessage);
                responseString = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
                httpResponseMessage.Result.EnsureSuccessStatusCode();
                Response[] response = new Response[3];
                if (request.method.Link == "participant")
                    return null;
                
                response = JsonConvert.DeserializeObject<Response[]>(responseString);
                return response;
               

            }
            catch
            {
                //string errorString = httpResponseMessage.Result.Content.ReadAsStringAsync().Result;
                MessageBox.Show("Эндпоинт 1С вернул ошибку: " + httpResponseMessage.Result.StatusCode +" "+ responseString);
                return null;
            }
        }
         
    }
}
