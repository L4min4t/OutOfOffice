using Backend.Lists.LeaveRequests;
using Backend.Repositories.Interfaces;
using Backend.Servises.Interfaces;

namespace Backend.Servises.Implementations;

public class LeaveRequestService : BaseService<LeaveRequest>, ILeaveRequestService
{
    public LeaveRequestService(IBaseRepository<LeaveRequest> repository) : base(repository)
    {
    }
}