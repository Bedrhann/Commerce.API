using FinalProject.Application.DTOs.User;
using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.UserFeatures.Queries.GetAllUsers
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly IUserQueryRepository _repository;

        public GetAllUserQueryHandler(IUserQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                List<User> Products = _repository.GetAll();
                List<UserDto> ProductDtos = Products.Adapt<List<UserDto>>();
                
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
                List<UserDto> ProductDtosList = ProductDtos.Skip(Skip).Take(request.Limit).ToList();//sayfalama bilgilerine göre gerektiği kadar veri gönderiyoruz.
                return new GetAllUserQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<UserDto>>(ProductDtosList),
                    PagingInfo = PageInfo
                };
            }
            catch (Exception ex)
            {
                Log.Error("GetAllProductsQueryHandler", ex);
                return new GetAllUserQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<UserDto>>(ex.Message),
                };
            }
        }
    }
}
