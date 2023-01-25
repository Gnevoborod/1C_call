using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1C_call.main
{
    internal class Connection
    {
        public Host[] Hosts;
        public Method[] Methods;
        private string AuthorisationPath = "..\\..\\settings\\auth.txt";
        private string HostsPath = "..\\..\\settings\\hosts.json";
        private string MethodsPath = "..\\..\\settings\\methods.json";
        enum Config {Hosts, Methods }
        public string Authorization;
        public bool CallsAllowed=false;//if something went wrong while config files loaded, then we can't allow 1c calls
        public Connection()
        {
            CallsAllowed=LoadAuth() 
                && LoadConnectionConf(Config.Hosts) 
                && LoadConnectionConf(Config.Methods);
        }

        private bool LoadAuth()
        {
            try
            {
                string authString = ReadConfigFile(AuthorisationPath);
                if(authString == null)
                {
                    return false;
                }
                var bytesToEncode = Encoding.UTF8.GetBytes(authString);
                Authorization = Convert.ToBase64String(bytesToEncode);
                return true;
            }
            catch
            {
                MessageBox.Show($"Данные в {AuthorisationPath} некорректны.\nОсуществление вызовов 1С невозможно.");
                return false;
            }
        }

        private bool LoadConnectionConf(Config config)
        {
            string path = config==Config.Hosts?HostsPath:MethodsPath;
            try
            {
                string dataFromSource;
                dataFromSource = ReadConfigFile(path);
                if (dataFromSource == null)
                {
                    return false;
                }
                if(config==Config.Hosts)
                    Hosts = JsonConvert.DeserializeObject<Host[]>(dataFromSource);
                else
                    Methods = JsonConvert.DeserializeObject<Method[]>(dataFromSource);
                return true;
            }
            catch
            {
                MessageBox.Show($"Данные в {path} некорректны.\nОсуществление вызовов 1С невозможно.");
                return false;
            }
        }

        private string ReadConfigFile(string path)
        {
            try
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                string result;
                using (StreamReader sr = new StreamReader(fs))
                {
                    result = sr.ReadToEnd();
                }
                return result;
            }
            catch
            {
                MessageBox.Show($"Не найден файл {path}\nОсуществление вызовов 1С невозможно.");
                return null;
            }
        }
    }
}
