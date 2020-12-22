using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_DotNetCore.Modal;

namespace WebApi_DotNetCore.Repository.Interface
{
    interface IDepartment
    {
        public string GetData();
        //public HttpResponseMessage getData1();

        public string CreateDepartment(Department dep);

        public IEnumerable<Department> GetAll();

        public string EditDepartment(Department dep);

        public string DeleteDepartment(int id);
    }

    //public class HttpResponseMessage
    //{
    //    public string ErrorCode { get; set; }
    //    public string Data { get; set; }
    //}
}
