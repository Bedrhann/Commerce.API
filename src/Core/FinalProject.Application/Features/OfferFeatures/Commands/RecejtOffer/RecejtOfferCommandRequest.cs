using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.OfferFeatures.Commands.RecejtOffer
{
    public class RecejtOfferCommandRequest : IRequest<BaseResponse<OfferDto>>
    {
        public int OwnerId { get; set; }
        public int OfferId { get; set; }
    }
}
