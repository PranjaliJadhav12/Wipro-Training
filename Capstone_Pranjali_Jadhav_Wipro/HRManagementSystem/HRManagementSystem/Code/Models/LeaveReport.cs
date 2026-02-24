namespace HRManagementSystem.Code.Models
{
    public class LeaveReport
    {
        public string? Name { get; set; }
        public string? DepartmentName { get; set; }
        public int DaysRequested { get; set; }
        public string? Status { get; set; }
    }
}