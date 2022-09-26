using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;

namespace FinalProject.Application.Features.OfferFeatures.Queries.GetIncomingOffer
{
    public class GetIncomingOffersQueryRequest : BasePagingRequest, IRequest<GetIncomingOffersQueryResponse>
    {
        public int UserId { get; set; }
        public string? SearchByName { get; set; }
    }
}
