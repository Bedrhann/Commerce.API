using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandRequest : IRequest<BaseResponse<ProductCreateDto>>
    {
        public ProductCreateDto ProductCreateDto { get; set; }
    }
}
