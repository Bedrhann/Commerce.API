using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Wrappers.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.OfferFeatures.Commands.DeleteOffer
{
    public class DeleteOfferCommandRequest : IRequest<BaseResponse<OfferDto>>
    {
        public int Id { get; set; }

    }
}
