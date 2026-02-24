namespace HRManagementSystem.Code.Models
{
    public class LeaveRequest
    {
        public int LeaveRequestId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string? Status { get; set; }
        public Employee? Employee { get; set; }
        public int DaysRequested { get; set; }
    }
}
