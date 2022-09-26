using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Features.OfferFeatures.Commands.AcceptOffer;
using FinalProject.Application.Features.OfferFeatures.Commands.CreateOffer;
using FinalProject.Application.Features.OfferFeatures.Commands.DeleteOffer;
using FinalProject.Application.Features.OfferFeatures.Commands.RecejtOffer;
using FinalProject.Application.Features.OfferFeatures.Commands.UpdateOffer;
using FinalProject.Application.Features.OfferFeatures.Queries.GetAllOffers;
using FinalProject.Application.Features.OfferFeatures.Queries.GetIncomingOffer;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace Paycore.FinalProject.API.Controllers
{
    [Authorize(Roles = "User,Admin")]
    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OffersController(IMediator mediator)//Mediator kütüphanesi ile işlemleri handler nesnelerine yönlendiriyoruz.
        {
            _mediator = mediator;
        }

        [HttpGet("outgoingoffers")]
        public async Task<IActionResult> GetAllOffers([FromQuery] GetOutgoingOffersQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);//Gelen token'ın içinden Id değerine göre kullanıcıyı belirleyip ona göre listesini döndürüyoruz.
            GetOutgoingOffersQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }
        [HttpGet("incomingoffers")]
        public async Task<IActionResult> GetAllOffers([FromQuery] GetIncomingOffersQueryRequest request)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;
            request.UserId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            GetIncomingOffersQueryResponse response = await _mediator.Send(request);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(response.PagingInfo));
            return Ok(response.BaseResponse);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferCommandRequest request)
        {
            BaseResponse<OfferCreateDto> response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOffer([FromBody] UpdateOfferCommandRequest request)
        {
            BaseResponse<OfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("{offerId}/accept")]
        public async Task<IActionResult> AcceptOffer([FromRoute] int offerId)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;//Kaçak girişleri engellemek için kullanıcının ıd bilgisini token içinden cekiyoruz.
            int OwnerId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            AcceptOfferCommandRequest request = new()
            {
                OfferId = offerId,
                OwnerId = OwnerId
            };
            BaseResponse<OfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpPut("{offerId}/reject")]
        public async Task<IActionResult> RecejtOffer([FromRoute] int offerId)
        {
            ClaimsIdentity Identity = (ClaimsIdentity)HttpContext.User.Identity;//Kaçak girişleri engellemek için kullanıcının ıd bilgisini token içinden cekiyoruz.
            int OwnerId = Int32.Parse(Identity.Claims.FirstOrDefault(x => x.Type == "Id").Value);
            RecejtOfferCommandRequest request = new()
            {
                OfferId = offerId,
                OwnerId = OwnerId
            };
            BaseResponse<OfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOffer([FromRoute] DeleteOfferCommandRequest request)
        {
            BaseResponse<OfferDto> response = await _mediator.Send(request);
            return Ok(response);
        }

    }
}
