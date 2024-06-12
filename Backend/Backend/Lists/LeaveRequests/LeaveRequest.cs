using Backend.Enums;
using Backend.Lists.Employees;

namespace Backend.Lists.LeaveRequests;

public class LeaveRequest
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }
    public Employee Employee { get; set; }

    public AbsenceReason AbsenceReason { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Comment { get; set; }

    public AbsenceRequestStatus Status { get; set; }
}