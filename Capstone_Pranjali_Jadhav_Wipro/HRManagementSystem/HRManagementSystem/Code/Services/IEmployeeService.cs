using HRManagementSystem.Code.Models;
using System.Collections.Generic;

namespace HRManagementSystem.Code.Services
{
    public interface IEmployeeService
    {
        List<Employee> GetAll();
        Employee? GetById(int id);
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}