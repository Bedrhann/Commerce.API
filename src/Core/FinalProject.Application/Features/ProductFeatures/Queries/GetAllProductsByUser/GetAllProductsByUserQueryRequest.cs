using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProducts;
using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductsByUser
{
    public class GetAllProductsByUserQueryRequest : BasePagingRequest, IRequest<GetAllProductsByUserQueryResponse>
    {
        public int UserId { get; set; }
        public string? SearchByName { get; set; }
    }
}
