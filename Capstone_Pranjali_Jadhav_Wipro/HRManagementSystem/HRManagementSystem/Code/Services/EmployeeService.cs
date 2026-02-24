using HRManagementSystem.Code.Models;
using HRManagementSystem.Code.Repositories;
using System.Linq;
using System.Collections.Generic;

namespace HRManagementSystem.Code.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public List<Employee> GetAll()
        {
            return _repo.GetAll();
        }

        public Employee? GetById(int id)
        {
            return _repo.GetAll().FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee emp)
        {
            if (_repo.GetAll().Any(e => e.Email == emp.Email))
                return;

            _repo.Add(emp);
        }
        public void Update(Employee employee)
        {
            _repo.Update(employee);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
    }
}