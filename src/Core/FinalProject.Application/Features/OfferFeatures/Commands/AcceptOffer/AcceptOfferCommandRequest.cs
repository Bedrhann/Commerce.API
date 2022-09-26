using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.OfferFeatures.Commands.AcceptOffer
{
    public class AcceptOfferCommandRequest : IRequest<BaseResponse<OfferDto>>
    {
        public int OwnerId { get; set; }
        public int OfferId { get; set; }
    }
}
