using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct
{
    public class UpdateProductCommandRequest : IRequest<BaseResponse<ProductDto>>
    {
        public ProductDto ProductDto { get; set; }
    }
}
