using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProducts
{
    public class GetAllProductsQueryRequest : BasePagingRequest, IRequest<GetAllProductsQueryResponse>
    {
        public string? SearchByName { get; set; }
    }
}

