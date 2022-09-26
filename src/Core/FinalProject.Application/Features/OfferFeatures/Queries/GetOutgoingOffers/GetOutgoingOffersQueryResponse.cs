using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;

namespace FinalProject.Application.Features.OfferFeatures.Queries.GetAllOffers
{
    public class GetOutgoingOffersQueryResponse
    {
        public BaseResponse<List<OfferDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
