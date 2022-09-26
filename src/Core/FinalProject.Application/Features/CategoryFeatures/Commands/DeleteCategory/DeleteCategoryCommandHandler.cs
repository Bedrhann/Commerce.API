using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, BaseResponse<CategoryDto>>
    {
        private readonly ICategoryCommandRepository _commandRepository;
        private readonly ICategoryQueryRepository _queryRepository;
        public DeleteCategoryCommandHandler(ICategoryCommandRepository repository, ICategoryQueryRepository queryRepository)
        {
            _commandRepository = repository;
            _queryRepository = queryRepository;
        }

        public async Task<BaseResponse<CategoryDto>> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Category category = _queryRepository.GetById(request.Id);
                if (category is null)
                {
                    return new BaseResponse<CategoryDto>("Record Not Found");
                }

                _commandRepository.BeginTransaction();
                _commandRepository.Delete(request.Id);
                _commandRepository.Commit();
                _commandRepository.CloseTransaction();

                return new BaseResponse<CategoryDto>(category.Adapt<CategoryDto>());
            }
            catch (Exception ex)
            {
                Log.Error("DeleteCategoryCommandHandler", ex);
                _commandRepository.Rollback();
                _commandRepository.CloseTransaction();
                return new BaseResponse<CategoryDto>(ex.Message);
            }
        }
    }
}
