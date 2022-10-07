using EpicTestRefactor.Application;
using EpicTestRefactor.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EpicTestRefactor.Controllers
{
    [ApiController]
    [Route("/api/Employees")]
    public class StaffController : ControllerBase
    {
        public EmployeeService EmployeeService { get; set; }

        public StaffController()
        {
            EmployeeService = new EmployeeService();
        }

        [HttpGet]
        [Route("get")]
        public async Task<Employee?> Get(int id)
        {
            return await EmployeeService.GetEmployee(id);
        }

        [HttpPost]
        [Route("create")]
        public async Task<Employee> Post(Employee employee)
        {
            return await EmployeeService.AddEmployee(employee);
        }

        [HttpPut]
        [Route("update")]
        public async Task<Employee> Put(Employee employee)
        {
            return await EmployeeService.UpdateEmployee(employee);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            //try
            //{
                var t = await EmployeeService.DeleteEmployee(id);
                return Ok();
            //}
            //catch
            //{
            //    return StatusCode(StatusCodes.Status204NoContent);
            //}
        }
    }
}
