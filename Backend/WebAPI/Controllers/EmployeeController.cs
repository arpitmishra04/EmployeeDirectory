using EmployeeManagement.Core.Interfaces;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : Controller
    {
        private IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public ActionResult GetAllEmployee()
        {
            List<EmployeeModel> employee = _employeeService.ViewAll();
            return Ok(employee);
        }
        [HttpPost]
        public ActionResult SetEmployee([FromBody] EmployeeModel employee)
        {
            _employeeService.Add(employee);
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateEmployee([FromBody] EmployeeModel employee)
        {
            _employeeService.Edit(employee);
            return Ok();
        }


        [HttpDelete]
        [Route("{employeeId}")]
        public ActionResult DeleteEmployee([FromRoute] string employeeId)
        {
            _employeeService.Delete(employeeId);
            return Ok();
        }
    }
}

