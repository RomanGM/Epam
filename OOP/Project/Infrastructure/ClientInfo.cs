using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    class ClientInfo
    {
        public int _id { get; }
        public string _name { get; }
        Dictionary<DateTime,string> _allRecords;

        public ClientInfo(int id, string name)
        {
            _id = id;
            _name = name;
            _allRecords = new Dictionary<DateTime, string>();
        }

        public void AddRecord(DateTime date, string record)
        {
            _allRecords.Add(date, record);
        }
    }
}
