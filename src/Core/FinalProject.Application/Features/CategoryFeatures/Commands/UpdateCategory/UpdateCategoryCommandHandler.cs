using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
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

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, BaseResponse<UpdateCategoryCommandRequest>>
    {
        private readonly ICategoryCommandRepository _commandRepository;
        private readonly ICategoryQueryRepository _queryRepository;
        public UpdateCategoryCommandHandler(ICategoryCommandRepository repository, ICategoryQueryRepository queryRepository)
        {
            _commandRepository = repository;
            _queryRepository = queryRepository;
        }
        public async Task<BaseResponse<UpdateCategoryCommandRequest>> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            
            try
            {
                Category category = _queryRepository.GetById(request.Id);
                if (category is null)
                {
                    return new BaseResponse<UpdateCategoryCommandRequest>("Record Not Found");
                }

                request.Adapt<UpdateCategoryCommandRequest, Category>(category);
                _commandRepository.BeginTransaction();
                _commandRepository.Update(category);
                _commandRepository.Commit();
                _commandRepository.CloseTransaction();

                //category.Adapt<Category, UpdateCategoryCommandRequest>(category);
                //var resource = mapper.Map<Entity, Dto>(entity);
                return new BaseResponse<UpdateCategoryCommandRequest>(request);
            }
            catch (Exception ex)
            {
                Log.Error("UpdateCategoryCommandHandler", ex);
                _commandRepository.Rollback();
                _commandRepository.CloseTransaction();
                return new BaseResponse<UpdateCategoryCommandRequest>(ex.Message);
            }
        }
    }
}
