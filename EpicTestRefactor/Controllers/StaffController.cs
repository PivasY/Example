using EpicTestRefactor.Application;
using EpicTestRefactor.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EpicTestRefactor.Controllers
{
    [ApiController]
    [Route("/api/Employees")]
    public class StaffController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public StaffController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _employeeService.GetEmployee(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Post([FromBody] Employee employee)
        {
            var result = await _employeeService.AddEmployee(employee);
            return Ok(result);
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            var result =  await _employeeService.UpdateEmployee(employee);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employeeService.DeleteEmployee(id);
            return Ok(id);
        }
    }
}
