using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;
using WebApi_DotNetCore.Repository.DataAccessLayer;

namespace WebApi_DotNetCore.Repository.BusinessLayer
{
    public class EmployeeBAL
    {

        EmployeeDAL objdal = new EmployeeDAL();

        public IEnumerable<Employee> GetAll()
        {
            return objdal.GetAll();
        }

        public string CreateEmployee(Employee emp)
        {
            return objdal.CreateEmployee(emp);
        }

        public string EditEmployee(Employee emp)
        {
            return objdal.EditEmployee(emp);
        }


        public string DeleteEmployee(int id)
        {
            return objdal.DeleteEmployee(id);
        }


    }
}
