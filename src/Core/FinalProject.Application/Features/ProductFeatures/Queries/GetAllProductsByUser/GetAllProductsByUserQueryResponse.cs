using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductsByUser
{
    public class GetAllProductsByUserQueryResponse
    {
        public BaseResponse<List<ProductDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
