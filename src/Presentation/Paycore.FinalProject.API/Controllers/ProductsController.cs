using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.DeleteProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProducts;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductsByUser;
using FinalProject.Application.Features.ProductFeatures.Queries.GetProductById;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Paycore.FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)//Mediator kütüphanesi ile işlemleri handler nesnelerine yönlendiriyoruz.
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct([FromQuery] GetAllProductsQueryRequest request)
        {

            GetAllProductsQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }
        [HttpGet("my-products")]
        public async Task<IActionResult> GetAllProductByUser([FromQuery] GetAllProductsByUserQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);//Gelen token'ın içinden Id değerine göre kullanıcıyı belirleyip ona göre listesini döndürüyoruz.
            GetAllProductsByUserQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProductById([FromRoute] GetProductByIdQueryRequest request)
        {
            BaseResponse<ProductDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;//Kaçak girişleri engellemek için kullanıcının ıd bilgisini token içinden cekiyoruz.
            request.ProductCreateDto.UserId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            BaseResponse<ProductCreateDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            BaseResponse<ProductDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommandRequest request)
        {
            BaseResponse<ProductDto> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
