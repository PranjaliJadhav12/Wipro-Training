namespace HRManagementSystem.Code.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
       
        public int DepartmentId { get; set; }
        public int LeaveBalance { get; set; }
        public Department? Department { get; set; }
        public ICollection<LeaveRequest>? LeaveRequests { get; set; }
    }
}
