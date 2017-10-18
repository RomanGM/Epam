using System;
using System.Linq;
using System.Collections.Generic;
using Project.Infrastructure;

namespace Project
{
    class Program
    {
        static void Main(string[] args)
        {
            var organization = new Clinic();

            var oculist = new Department("отделение окулистов");
            var surgical = new Department("хирургическое отделение");
            organization.AddDepartment(oculist);
            organization.AddDepartment(surgical);

            List<Client> allClients = new List<Client>();

            allClients.Add(new Client("Roman"));
            allClients.Add(new Client("Anton"));
            allClients.Add(new Client("Egor"));
            allClients.Add(new Client("Oleg"));

            oculist.AddClients(allClients.GetRange(0, 2));
            surgical.AddClients(allClients.GetRange(2, 2));

            foreach (var client in surgical._departmentClients)
            {
                client.AddInfo(new ClientInfo[] { new ClientInfo(1, "перелом ноги"), new ClientInfo(2, "ушиб колена") });
            }

            oculist._departmentClients[0].AddInfo(new ClientInfo[] { new ClientInfo(1, "повреждение сетчатки"),
                                                                     new ClientInfo(2, "ухудшение зрения") });
            oculist._departmentClients[1].AddInfo(new ClientInfo[] { new ClientInfo(1, "повреждение века") });

            surgical._departmentClients[0]._allInfoClient[0].AddRecord(new DateTime(2017,9,11),"первичный осмотр");

            Console.WriteLine("Введите диагноз (например - ушиб ноги)");
            string diagnosis = Console.ReadLine();

            int countClients = organization._allDepartment.Sum(x => x._departmentClients
                                                          .Sum(y => y._allInfoClient
                                                          .Count(z => z._name == diagnosis)));
            Console.WriteLine("Найдено " + countClients);
        }
    }
}
