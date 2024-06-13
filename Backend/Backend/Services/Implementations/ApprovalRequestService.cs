using Backend.Lists.ApprovalRequests;
using Backend.Repositories.Interfaces;
using Backend.Services.Interfaces;

namespace Backend.Services.Implementations;

public class ApprovalRequestService : BaseService<ApprovalRequest>, IApprovalRequestService
{
    public ApprovalRequestService(IApprovalRequestRepository repository) : base(repository)
    {
    }
}