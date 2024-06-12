using Backend.Lists.ApprovalRequests;
using Backend.Repositories.Interfaces;
using Backend.Servises.Interfaces;

namespace Backend.Servises.Implementations;

public class ApprovalRequestService : BaseService<ApprovalRequest>, IApprovalRequestService
{
    public ApprovalRequestService(IBaseRepository<ApprovalRequest> repository) : base(repository)
    {
    }
}