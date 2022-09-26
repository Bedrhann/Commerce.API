using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.OfferFeatures.Commands.UpdateOffer
{
    public class UpdateOfferCommandRequest : IRequest<BaseResponse<OfferDto>>
    {
        public OfferUpdateDto OfferUpdateDto { get; set; }
    }
}
