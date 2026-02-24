using HRManagementSystem.Code.Models;
using HRManagementSystem.Code.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HRManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult GetAll()
        {
            var employees = _employeeService.GetAll();
            return Ok(employees);
        }

        // GET: api/Employee/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetById(id);

            if (employee == null)
                return NotFound($"Employee with Id {id} not found.");

            return Ok(employee);
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            var existing = _employeeService.GetAll()
                    .FirstOrDefault(e => e.Email == employee.Email);

            if (existing != null)
                return BadRequest("Duplicate employee email!");
            _employeeService.Add(employee);

            return CreatedAtAction(
                nameof(GetById),
                new { id = employee.EmployeeId },
                employee
            );
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            _employeeService.Update(employee);
            return Ok("Employee Updated Successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.Delete(id);
            return Ok("Employee Deleted Successfully");
        }
    }
}