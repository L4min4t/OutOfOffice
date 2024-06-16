using Backend.Lists.LeaveRequests;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class LeaveRequestService
    : BaseService<LeaveRequest>, ILeaveRequestService
{
    public LeaveRequestService(ILeaveRequestRepository repository)
        : base(repository)
    {
    }
}
