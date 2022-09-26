using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Wrappers.Response;
using MediatR;

namespace FinalProject.Application.Features.OfferFeatures.Commands.CreateOffer
{
    public class CreateOfferCommandRequest : IRequest<BaseResponse<OfferCreateDto>>
    {
        public OfferCreateDto OfferDto { get; set; }
    }
}
