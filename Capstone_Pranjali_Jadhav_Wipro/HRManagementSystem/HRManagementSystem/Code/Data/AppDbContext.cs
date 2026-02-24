using Microsoft.EntityFrameworkCore;
using HRManagementSystem.Code.Models;

namespace HRManagementSystem.Code.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeaveReport> LeaveReports { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeaveReport>()
                .HasNoKey()
                .ToView("vw_LeaveReport");
        }
    }
}