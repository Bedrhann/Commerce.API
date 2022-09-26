using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryRequest : BasePagingRequest, IRequest<GetAllCategoriesQueryResponse>
    {
        public string? SearchByName { get; set; }
    }
}
