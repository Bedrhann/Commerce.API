using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.ProductFeatures.Queries.GetAllProductsByUser
{
    public class GetAllProductsByUserQueryHandler : IRequestHandler<GetAllProductsByUserQueryRequest, GetAllProductsByUserQueryResponse>
    {
        private readonly IProductQueryRepository _repository;

        public GetAllProductsByUserQueryHandler(IProductQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllProductsByUserQueryResponse> Handle(GetAllProductsByUserQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<Product> Products = _repository.GetAll();
                Products = Products.Where(x => x.UserId == request.UserId).ToList();
                List<ProductDto> ProductDtos = Products.Adapt<List<ProductDto>>();
                
                int TotalUser = ProductDtos.Count();
                int TotalPage = (int)Math.Ceiling(TotalUser / (double)request.Limit);//sayfalama bilgilerini hesaplıyoruz
                int Skip = (request.Page - 1) * request.Limit;

                PagingInfo PageInfo = new()//sayfalama yapısını doldurup ona göre dönüş yapıyoruz.
                {
                    TotalData = TotalUser,
                    TotalPage = TotalPage,
                    PageLimit = request.Limit,
                    PageNum = request.Page,
                    HasNext = request.Page >= TotalPage ? false : true,
                    HasPrevious = request.Page == 1 ? false : true,
                };
                List<ProductDto> ProductDtosList = ProductDtos.Skip(Skip).Take(request.Limit).ToList();//sayfalama bilgilerine göre gerektiği kadar veri gönderiyoruz.
                return new GetAllProductsByUserQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<ProductDto>>(ProductDtosList),
                    PagingInfo = PageInfo
                };
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductsByUserQueryHandler", ex);
                return new GetAllProductsByUserQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<ProductDto>>(ex.Message),
                };
            }
        }
    }
}
