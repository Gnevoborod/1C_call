using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1C_call.main
{
    internal class Connection
    {
        public List<Host> hosts;
        public List<Method> methods;
        public Connection()
        {
            hosts= new List<Host>();
            
            hosts.Add(new Host("Тест", @"https://146.185.243.56/kontur_buh_test/ru/hs/reestrUEApi/v1/"));
            hosts.Add(new Host("Прод", @"https://146.185.243.56/kontur_buh/ru/hs/reestrUEApi/v1/"));

            methods = new List<Method>();
            methods.Add(new Method("Создание участника", "participant","POST"));
            methods.Add(new Method("Создание счёта", "payment_create_account", "POST"));
            methods.Add(new Method("Регистрация КП", "payment_project", "POST"));
            methods.Add(new Method("Зачисление УЕ", "payment_cu_credit", "POST"));
            methods.Add(new Method("Передача УЕ", "payment_cu_debit", "POST"));
            methods.Add(new Method("Зачёт УЕ", "payment_cu_debit", "POST"));
            methods.Add(new Method("Изменение КП", "payment_project", "PUT"));
            methods.Add(new Method("Изменение участника", "participant", "PUT"));

        }
    }
}
