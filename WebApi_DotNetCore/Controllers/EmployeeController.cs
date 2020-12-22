using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_DotNetCore.Modal;
using WebApi_DotNetCore.Repository.BusinessLayer;

namespace WebApi_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeBAL employeeBAL;
        public EmployeeController()
        {
            employeeBAL = new EmployeeBAL();
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

            IEnumerable<Employee> employee = employeeBAL.GetAll();

            if (employee != null)
            {
                return Ok(new { success = true, response = employee });
            }

            else
            {
                return Ok(new { success = false, response = "Data Not Found" });
            }
        }

        [HttpPost("CreateEmployee")]
        public IActionResult CreateEmployee(Employee emp)
        {
            string addemp = employeeBAL.CreateEmployee(emp);
            return Ok(addemp);
        }

        [HttpPut("EditEmployee")]
        public IActionResult EditEmployee(Employee emp)
        {
            string edtemp = employeeBAL.EditEmployee(emp);
            return Ok(edtemp);
        }

        [HttpDelete("DeleteEmployee")]
        public IActionResult DeleteEmployee(int id)
        {
            string dltemp = employeeBAL.DeleteEmployee(id);
            return Ok(dltemp);
        }
    }
}
