using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Infrastructure
{
    class Clinic
    {
        public List<Department> _allDepartment { get; }

        public Clinic()
        {
            _allDepartment = new List<Department>();
        }

        public void AddDepartment(Department newDepartment)
        {
            _allDepartment.Add(newDepartment);
        }
    }
}
