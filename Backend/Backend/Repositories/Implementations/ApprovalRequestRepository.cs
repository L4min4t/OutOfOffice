using Backend.Contexts;
using Backend.Lists.ApprovalRequests;
using Backend.Repositories.Interfaces;

namespace Backend.Repositories.Implementations;

public class ApprovalRequestRepository : BaseRepository<ApprovalRequest>, IApprovalRequestRepository
{
    public ApprovalRequestRepository(ApplicationContext context) : base(context)
    {
    }
}