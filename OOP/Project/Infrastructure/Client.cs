using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    class Client
    {
        public string _clientName { get; }
        public List<ClientInfo> _allInfoClient { get; }

        public Client(string name)
        {
            _clientName = name;
            _allInfoClient = new List<ClientInfo>();
        }

        public void AddInfo(ClientInfo[] newInfo)
        {
            _allInfoClient.AddRange(newInfo);
        }
    }
}
