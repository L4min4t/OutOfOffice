using Backend.Contexts;
using Backend.Lists.LeaveRequests;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations;

public class LeaveRequestRepository
    : BaseRepository<LeaveRequest>, ILeaveRequestRepository

{
    public LeaveRequestRepository(ApplicationContext context)
        : base(context)
    {
    }
}
