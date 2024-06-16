using Backend.Lists.Employees;
using Backend.Lists.LeaveRequests;

namespace Backend.Lists.ApprovalRequests;

public class ApprovalRequest : IEntity
{
    public int ApproverId { get; set; }
    public Employee Approver { get; set; }
    
    public int LeaveRequestId { get; set; }
    public LeaveRequest LeaveRequest { get; set; }
    
    public LeaveApprovalStatus Status { get; set; }
    
    public string Comment { get; set; }
    public int Id { get; set; }
}

public enum LeaveApprovalStatus
{
    New,
    Approved,
    Rejected
}