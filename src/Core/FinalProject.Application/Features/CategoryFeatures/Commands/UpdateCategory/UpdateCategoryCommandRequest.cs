using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<BaseResponse<UpdateCategoryCommandRequest>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
