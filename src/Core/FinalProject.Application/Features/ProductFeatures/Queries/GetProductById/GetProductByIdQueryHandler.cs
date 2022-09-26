using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetProductById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQueryRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductQueryRepository _repository;

        public GetProductByIdQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<BaseResponse<ProductDto>> Handle(GetProductByIdQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product products = _repository.GetById(request.Id);
                ProductDto productDto = products.Adapt<ProductDto>();

                return new BaseResponse<ProductDto>(productDto);
            }
            catch (Exception ex)
            {
                Log.Error("GetProductByIdQueryHandler", ex);
                return new BaseResponse<ProductDto>(ex.Message);
            }
        }
    }
}

