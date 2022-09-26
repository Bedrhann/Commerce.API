using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<BaseResponse<CategoryDto>>
    {
        public int Id { get; set; }
    }
}
