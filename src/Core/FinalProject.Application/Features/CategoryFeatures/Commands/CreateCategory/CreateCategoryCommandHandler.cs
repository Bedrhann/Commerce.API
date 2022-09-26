using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, BaseResponse<CategoryDto>>
    {
        private readonly ICategoryCommandRepository _repository;

        public CreateCategoryCommandHandler(ICategoryCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<BaseResponse<CategoryDto>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Category NewCategory = request.Adapt<Category>();

                _repository.BeginTransaction();
                _repository.Save(NewCategory);
                _repository.Commit();
                _repository.CloseTransaction();

                return new BaseResponse<CategoryDto>(NewCategory.Adapt<CategoryDto>());
            }
            catch (Exception ex)
            {
                Log.Error("CreateCategoryCommandHandler", ex);
                _repository.Rollback();
                _repository.CloseTransaction();
                return new BaseResponse<CategoryDto>(ex.Message);
            }
        }
    }
}
