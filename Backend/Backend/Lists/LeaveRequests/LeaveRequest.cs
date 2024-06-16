using Backend.Lists.Employees;

namespace Backend.Lists.LeaveRequests;

public class LeaveRequest : IEntity
{
    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }
    
    public AbsenceReason AbsenceReason { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    public string Comment { get; set; }
    
    public AbsenceRequestStatus Status { get; set; }
    public int Id { get; set; }
}

public enum AbsenceReason
{
    SickLeave,
    Vacation,
    PersonalLeave,
    MaternityLeave,
    PaternityLeave
}

public enum AbsenceRequestStatus
{
    New,
    Approved,
    Rejected,
    Cancelled
}
