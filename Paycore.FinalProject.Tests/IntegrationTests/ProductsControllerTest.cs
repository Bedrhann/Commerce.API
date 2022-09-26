using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.CreateProduct;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductsByUser;
using FinalProject.Application.Wrappers.Response;
using System.Text;
using System.Text.Json;
using Xunit;

namespace Paycore.FinalProject.Tests.IntegrationTests
{
    public class ProductsControllerTest : IClassFixture<FakeApplication>
    {
        private readonly HttpClient _httpClient;
        public ProductsControllerTest(FakeApplication factory) => _httpClient = factory.CreateClient();

        [Fact]
        public async void ProductCrudProcess()
        {
            //GET****************
            GetAllProductsByUserQueryRequest RequestGet = new GetAllProductsByUserQueryRequest()
            {
                UserId = 2
            };
            HttpResponseMessage responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.UserId}");
            responseGet.EnsureSuccessStatusCode();
            string contentGet = await responseGet.Content.ReadAsStringAsync();
            BaseResponse<List<ProductDto>> commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductDto>>>(contentGet);
            Assert.NotNull(commentGet);
            int firstCount = commentGet.Response.Count();

            //CREATE****************
            CreateProductCommandRequest createRequest = new CreateProductCommandRequest()
            {
                ProductCreateDto = new ProductCreateDto()
                {
                    UserId = 1,
                    Name = "sss",
                    Brand = "sss",
                    Color = "sss",
                    Description = "sss",
                    CategoryId = 1,
                    IsOfferable = true,
                    Price = 111
                }
            };
            var bodyCreate = new StringContent(JsonSerializer.Serialize(createRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseCreate = await _httpClient.PostAsync("/api/products", bodyCreate);
            responseCreate.EnsureSuccessStatusCode();
            string contentCreate = await responseCreate.Content.ReadAsStringAsync();
            BaseResponse<ProductDto> commentCreate = JsonSerializer.Deserialize<BaseResponse<ProductDto>>(contentCreate);
            Assert.NotNull(commentCreate);
            Assert.NotNull(commentCreate.Message);
            Assert.NotNull(commentCreate.Response.Id);
            Assert.True(commentCreate.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.UserId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductDto>>>(contentGet);
            Assert.NotNull(commentGet);
            int afterCreationCount = commentGet.Response.Count();
            Assert.True((afterCreationCount - 1) == firstCount);

            //GETBYID**************
            HttpResponseMessage responseGetById = await _httpClient.GetAsync($"/api/products/{commentCreate.Response.Id}");
            responseGetById.EnsureSuccessStatusCode();
            string contentGetById = await responseGetById.Content.ReadAsStringAsync();
            ProductDto commentGetById = JsonSerializer.Deserialize<ProductDto>(contentGetById);
            Assert.NotNull(commentGetById);

            //UPDATE****************
            UpdateProductCommandRequest updateRequest = new UpdateProductCommandRequest()
            {
                ProductDto = new ProductDto()
                {
                    Id = commentCreate.Response.Id,
                    Name = "sssguncellendi",
                    Brand = "sssguncellendi",
                    Color = "sssguncellendi",
                    Description = "sssguncellendi",
                    CategoryId = 2,
                    IsOfferable = true,
                    Price = 222
                }
            };
            var bodyUpdate = new StringContent(JsonSerializer.Serialize(updateRequest), Encoding.UTF8, "application/json");
            HttpResponseMessage responseUpdate = await _httpClient.PutAsync("/api/products", bodyUpdate);
            responseUpdate.EnsureSuccessStatusCode();
            string contentUpdate = await responseUpdate.Content.ReadAsStringAsync();
            BaseResponse<ProductDto> commentUpdate = JsonSerializer.Deserialize<BaseResponse<ProductDto>>(contentUpdate);
            Assert.NotNull(commentUpdate);
            Assert.NotNull(commentUpdate.Message);
            Assert.True(commentUpdate.Success);

            //DELETE****************
            HttpResponseMessage responseDelete = await _httpClient.DeleteAsync($"/api/products/{commentCreate.Response.Id}");
            responseDelete.EnsureSuccessStatusCode();
            string contentDelete = await responseDelete.Content.ReadAsStringAsync();
            BaseResponse<ProductDto> commentDelete = JsonSerializer.Deserialize<BaseResponse<ProductDto>>(contentDelete);
            Assert.NotNull(commentDelete);
            Assert.NotNull(commentDelete.Message);
            Assert.True(commentDelete.Success);

            //GET****************
            responseGet = await _httpClient.GetAsync($"/api/products?CategoryId={RequestGet.UserId}");
            responseGet.EnsureSuccessStatusCode();
            contentGet = await responseGet.Content.ReadAsStringAsync();
            commentGet = JsonSerializer.Deserialize<BaseResponse<List<ProductDto>>>(contentGet);
            Assert.NotNull(commentGet);
            int lastCount = commentGet.Response.Count();

            Assert.True(lastCount == firstCount);
        }
    }
}
