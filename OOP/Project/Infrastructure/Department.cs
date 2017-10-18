using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    class Department
    {
        public string _departmentName { get; }
        public List<Client> _departmentClients { get; }

        public Department(string name)
        {
            _departmentName = name;
            _departmentClients = new List<Client>();
        }

        public void AddClients(List<Client> newClients)
        {
            _departmentClients.AddRange(newClients);
        }
    }
}
