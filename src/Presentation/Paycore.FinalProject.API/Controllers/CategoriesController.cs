using FinalProject.Application.DTOs.Category;
using FinalProject.Application.Features.CategoryFeatures.Commands.CreateCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.DeleteCategory;
using FinalProject.Application.Features.CategoryFeatures.Commands.UpdateCategory;
using FinalProject.Application.Features.CategoryFeatures.Queries.GetAllCategories;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paycore.FinalProject.Domain.Entities;
using System.Text.Json;

namespace Paycore.FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)//Mediator kütüphanesi ile işlemleri handler nesnelerine yönlendiriyoruz.
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesQueryRequest request)
        {

            GetAllCategoriesQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            BaseResponse<CategoryDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommandRequest request)
        {
            BaseResponse<UpdateCategoryCommandRequest> response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] DeleteCategoryCommandRequest request)
        {
            BaseResponse<CategoryDto> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
