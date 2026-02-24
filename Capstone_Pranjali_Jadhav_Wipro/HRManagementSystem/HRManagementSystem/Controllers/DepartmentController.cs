using Microsoft.AspNetCore.Mvc;
using HRManagementSystem.Code.Data;
using HRManagementSystem.Code.Models;
using System.Linq;

namespace HRManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Departments.ToList());
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return Ok(department);
        }
    }
}