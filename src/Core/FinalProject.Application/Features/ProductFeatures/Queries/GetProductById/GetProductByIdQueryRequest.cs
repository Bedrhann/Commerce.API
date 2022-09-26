using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryRequest : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
