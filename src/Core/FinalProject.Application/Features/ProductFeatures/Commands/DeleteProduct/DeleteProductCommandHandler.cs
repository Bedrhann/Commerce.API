using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommandRequest, BaseResponse<ProductDto>>
    {
        private readonly IProductCommandRepository _commandRepository;
        private readonly IProductQueryRepository _queryRepository;
        public DeleteProductCommandHandler(IProductCommandRepository repository, IProductQueryRepository queryRepository)
        {
            _commandRepository = repository;
            _queryRepository = queryRepository;
        }

        public async  Task<BaseResponse<ProductDto>> Handle(DeleteProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product product = _queryRepository.GetById(request.Id);
                if (product is null)
                {
                    return new BaseResponse<ProductDto>("Record Not Found");
                }

                _commandRepository.BeginTransaction();
                _commandRepository.Delete(request.Id);
                _commandRepository.Commit();
                _commandRepository.CloseTransaction();

                return new BaseResponse<ProductDto>(product.Adapt<ProductDto>());
            }
            catch (Exception ex)
            {
                Log.Error("DeleteProductCommandHandler", ex);
                _commandRepository.Rollback();
                _commandRepository.CloseTransaction();
                return new BaseResponse<ProductDto>(ex.Message);
            }
        }
    }
}
