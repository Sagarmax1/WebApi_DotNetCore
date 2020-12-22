using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;

namespace WebApi_DotNetCore.Repository.Interface
{
    interface IEmployee
    {
        public string GetData();
        public string CreateEmployee(Employee emp);

        public IEnumerable<Employee> GetAll();

        public string EditEmployee(Employee dep);

        public string DeleteEmployee(int id);
    }
}
