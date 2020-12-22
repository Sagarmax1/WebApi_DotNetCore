using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_DotNetCore.Modal;
using WebApi_DotNetCore.Repository.BusinessLayer;

namespace WebApi_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly DepartmentBAL departmentBAL;
        public DepartmentController()
        {
            departmentBAL = new DepartmentBAL();
        }

        //[HttpGet("getData1")]
        //public HttpResponseMessage getData1()
        //{
        //    getdep = departmentBAL.getData1();
        //    return Ok(getdep);
        //}


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            // List<Department> department = new List<Department>();

            IEnumerable<Department> department = departmentBAL.GetAll();

            if (department != null)
            {
                return Ok(new { success = true, response = department });
            }

            else
            {
                return Ok(new { success = false, response = "Data Not Found" });
            }
        }

        [HttpPost("CreateDepartment")]
        public IActionResult CreateDepartment(Department dep)
        {
            string adddep = departmentBAL.CreateDepartment(dep);
            return Ok(adddep);
        }

        [HttpPut("EditDepartment")]
        public IActionResult EditDepartment(Department dep)
        {
            string edtdep = departmentBAL.EditDepartment(dep);
            return Ok(edtdep);
        }

        [HttpDelete("DeleteDepartment")]
        public IActionResult DeleteDepartment(int id)
        {
            string dltdep = departmentBAL.DeleteDepartment(id);
            return Ok(dltdep);
        }




    }
}
