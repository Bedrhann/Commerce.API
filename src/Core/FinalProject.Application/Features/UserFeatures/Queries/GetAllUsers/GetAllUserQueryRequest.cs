using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUsers
{
    public class GetAllUserQueryRequest : BasePagingRequest, IRequest<GetAllUserQueryResponse>
    {
    }
}
