using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;
using WebApi_DotNetCore.Repository.DataAccessLayer;

namespace WebApi_DotNetCore.Repository.BusinessLayer
{
    public class DepartmentBAL
    {
        DepartmentDAL objdal = new DepartmentDAL();


        public IEnumerable<Department> GetAll()
        {
            return objdal.GetAll();
        }

        public string CreateDepartment (Department dep)
        {
            return objdal.CreateDepartment(dep);
        }

        public string EditDepartment(Department dep)
        {
            return objdal.EditDepartment(dep);
        }


        public string DeleteDepartment(int id)
        {
            return objdal.DeleteDepartment(id);
        }


        //public HttpResponseMessage getData1()
        //{
        //    return objdal.getData1();
        //}





    }
}
