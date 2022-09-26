using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;

namespace FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryResponse
    {
        public BaseResponse<List<CategoryDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
