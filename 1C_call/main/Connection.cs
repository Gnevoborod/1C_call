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
        public List<Host> Hosts;
        public List<Method> Methods;
        private string AuthorisationPath = "..\\..\\settings\\auth.txt";
        public string Authorization;
        public Connection()
        {
            Hosts = new List<Host>();

            Hosts.Add(new Host("Тест", @"https://146.185.243.56/kontur_buh_test/ru/hs/reestrUEApi/v1/"));
            Hosts.Add(new Host("Прод", @"https://146.185.243.56/kontur_buh/ru/hs/reestrUEApi/v1/"));

            Methods = new List<Method>();
            Methods.Add(new Method("Создание участника", "participant","POST"));
            Methods.Add(new Method("Создание счёта", "payment_create_account", "POST"));
            Methods.Add(new Method("Регистрация КП", "payment_project", "POST"));
            Methods.Add(new Method("Зачисление УЕ", "payment_cu_credit", "POST"));
            Methods.Add(new Method("Передача УЕ", "payment_cu_debit", "POST"));
            Methods.Add(new Method("Зачёт УЕ", "payment_cu_debit", "POST"));
            Methods.Add(new Method("Изменение КП", "payment_project", "PUT"));
            Methods.Add(new Method("Изменение участника", "participant", "PUT"));
            Methods.Add(new Method("Повторное получение документов", "payment_files", "POST"));


            try
            {
                FileStream fs = new FileStream(AuthorisationPath, FileMode.Open);
                
                using(StreamReader sr=new StreamReader(fs))
                {
                    Authorization = sr.ReadToEnd();
                }
                var bytesToEncode=Encoding.UTF8.GetBytes(Authorization);
                Authorization=Convert.ToBase64String(bytesToEncode);
            }
            catch
            {
                MessageBox.Show("Не найден файл settings\\auth.txt\nОсуществление вызовов 1С невозможно.");
            }
        }
    }
}
