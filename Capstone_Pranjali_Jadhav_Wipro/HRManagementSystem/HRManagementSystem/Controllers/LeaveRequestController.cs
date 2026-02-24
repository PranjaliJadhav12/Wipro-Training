using HRManagementSystem.Code.Data;
using HRManagementSystem.Code.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class LeaveRequestController : ControllerBase
{
    private readonly AppDbContext _context;

    public LeaveRequestController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        var leaveRequests = _context.LeaveRequests
        .Include(l => l.Employee)
        .ToList();

        return Ok(leaveRequests);
    }

    [HttpPost]
    public IActionResult Post(LeaveRequest request)
    {
        request.DaysRequested = (request.ToDate - request.FromDate).Days + 1;
        request.Status = "Pending";
        _context.LeaveRequests.Add(request);
        _context.SaveChanges();
        return Ok(request);
    }
    [HttpPut("approve/{id}")]
    public IActionResult Approve(int id)
    {
        _context.Database.ExecuteSqlRaw(
            "EXEC sp_ApproveLeave @LeaveRequestId = {0}", id);

        return Ok("Leave Approved Successfully");
    }
}