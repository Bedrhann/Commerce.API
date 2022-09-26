using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, BaseResponse<ProductCreateDto>>
    {
        private readonly IProductCommandRepository _productCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly ICategoryQueryRepository _categoryQueryRepository;

        public CreateProductCommandHandler(IProductCommandRepository repository, IUserQueryRepository queryRepository, ICategoryQueryRepository categoryQueryRepository)
        {
            _productCommandRepository = repository;
            _userQueryRepository = queryRepository;
            _categoryQueryRepository = categoryQueryRepository;
        }
        public async Task<BaseResponse<ProductCreateDto>> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Product newProduct = request.ProductCreateDto.Adapt<Product>();
                User user = _userQueryRepository.GetById(request.ProductCreateDto.UserId);
                Category category = _categoryQueryRepository.GetById(request.ProductCreateDto.CategoryId);
                newProduct.User = user;//bağlantılı tabloları ıd ile cekip verileri Product nesnesine dolduruyoruz.
                newProduct.Category = category;
                _productCommandRepository.BeginTransaction();
                _productCommandRepository.Save(newProduct);
                _productCommandRepository.Commit();
                _productCommandRepository.CloseTransaction();

                return new BaseResponse<ProductCreateDto>(request.ProductCreateDto);
            }
            catch (Exception ex)
            {
                Log.Error("CreateProductCommandHandler", ex);
                _productCommandRepository.Rollback();
                _productCommandRepository.CloseTransaction();
                return new BaseResponse<ProductCreateDto>(ex.Message);
            }
        }
    }
}
