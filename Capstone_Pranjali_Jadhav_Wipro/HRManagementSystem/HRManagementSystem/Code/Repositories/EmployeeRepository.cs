using HRManagementSystem.Code.Data;
using HRManagementSystem.Code.Models;
using Microsoft.EntityFrameworkCore;

namespace HRManagementSystem.Code.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        // Constructor Injection
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get All Employees
        public List<Employee> GetAll()
        {
            return _context.Employees
                   .Include(e => e.Department)
                   .ToList();
        }

        // Get Employee By Id
        public Employee? GetById(int id)
        {
            return _context.Employees
                           .Include(e => e.Department)
                           .FirstOrDefault(e => e.EmployeeId == id);
        }

        // Add Employee
        public void Add(Employee employee)
        {
            _context.ChangeTracker.Clear();
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Update(Employee employee)
        {
            var existingEmployee = _context.Employees
                .Include(e => e.Department)   // ADD THIS
                .FirstOrDefault(e => e.EmployeeId == employee.EmployeeId);

            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.DepartmentId = employee.DepartmentId;
                existingEmployee.LeaveBalance = employee.LeaveBalance;

                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var employee = _context.Employees
                .FirstOrDefault(e => e.EmployeeId == id);

            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}