using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandRequest : IRequest<BaseResponse<ProductDto>>
    {
        public int Id { get; set; }
    }
}
