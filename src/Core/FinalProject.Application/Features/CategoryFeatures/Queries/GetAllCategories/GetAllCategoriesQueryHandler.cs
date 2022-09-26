using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, GetAllCategoriesQueryResponse>
    {
        private readonly ICategoryQueryRepository _repository;

        public GetAllCategoriesQueryHandler(ICategoryQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllCategoriesQueryResponse> Handle(GetAllCategoriesQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Category> Categories = _repository.GetAll();

                if (!string.IsNullOrWhiteSpace(request.SearchByName))
                {
                    Categories = Categories.Where(x => x.Name.Contains(request.SearchByName)).ToList();
                }
                int TotalUser = Categories.Count();
                int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);
                int Skip = (request.Page - 1) * request.Limit;

                PagingInfo PageInfo = new()
                {
                    TotalData = TotalUser,
                    TotalPage = TotalPage,
                    PageLimit = request.Limit,
                    PageNum = request.Page,
                    HasNext = request.Page >= TotalPage ? false : true,
                    HasPrevious = request.Page == 1 ? false : true,
                };
                List<Category> CategoriesList = Categories.Skip(Skip).Take(request.Limit).ToList();

                return new GetAllCategoriesQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<CategoryDto>>(CategoriesList.Adapt<List<CategoryDto>>()),
                    PagingInfo = PageInfo
                };
            }
            catch (Exception ex)
            {
                Log.Error("GetAllCategoriesQueryHandler", ex);
                return new GetAllCategoriesQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<CategoryDto>>(ex.Message),
                };
            }
        }
    }
}
