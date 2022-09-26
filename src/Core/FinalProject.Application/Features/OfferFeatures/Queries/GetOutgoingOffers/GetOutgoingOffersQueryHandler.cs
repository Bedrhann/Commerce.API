using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.OfferFeatures.Queries.GetAllOffers
{
    public class GetOutgoingOffersQueryHandler : IRequestHandler<GetOutgoingOffersQueryRequest, GetOutgoingOffersQueryResponse>
    {
        private readonly IOfferQueryRepository _repository;

        public GetOutgoingOffersQueryHandler(IOfferQueryRepository repository)
        {
            _repository = repository;
        }
        public async Task<GetOutgoingOffersQueryResponse> Handle(GetOutgoingOffersQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                IQueryable<Offer> OffersQuery = _repository.Entities;
                List<Offer> Offers = OffersQuery.Where(x => x.User.Id == request.UserId).ToList();
                List<OfferDto> OffersDtos = Offers.Adapt<List<OfferDto>>();
                for (int i = 0; i < OffersDtos.Count; i++)
                {
                    OffersDtos[i].BuyerId = Offers[i].User.Id;//veritabanından gelen verilerin ilişkili tablolardan ıd nesnelerini alıp gerekli değerlere atamalarını yapıyoruz.
                    OffersDtos[i].ProductId = Offers[i].Product.Id;
                }
                int TotalUser = OffersDtos.Count();
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
                List<OfferDto> OfferDtosList = OffersDtos.Skip(Skip).Take(request.Limit).ToList();//sayfalama bilgilerine göre gerektiği kadar veri gönderiyoruz.
                return new GetOutgoingOffersQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<OfferDto>>(OfferDtosList),
                    PagingInfo = PageInfo
                };
            }
            catch (Exception ex)
            {
                Log.Error("GetOutgoingOffersQueryHandler", ex);
                return new GetOutgoingOffersQueryResponse()
                {
                    BaseResponse = new BaseResponse<List<OfferDto>>(ex.Message),
                };
            }
        }
    }
}
