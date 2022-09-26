using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Models.Paging;
using FinalProject.Application.Wrappers.Response;

namespace FinalProject.Application.Features.OfferFeatures.Queries.GetIncomingOffer
{
    public class GetIncomingOffersQueryResponse
    {
        public BaseResponse<List<OfferDto>> BaseResponse { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
