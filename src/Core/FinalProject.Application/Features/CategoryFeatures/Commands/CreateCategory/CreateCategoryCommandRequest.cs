using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Paycore.FinalProject.Domain.Entities;

namespace FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<BaseResponse<CategoryDto>>
    {
        public string Name { get; set; }
    }
}
