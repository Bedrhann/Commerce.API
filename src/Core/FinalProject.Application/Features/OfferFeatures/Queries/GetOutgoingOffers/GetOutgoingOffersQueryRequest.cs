using FinalProject.Application.Wrappers.NewFolder.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.OfferFeatures.Queries.GetAllOffers
{
    public class GetOutgoingOffersQueryRequest : BasePagingRequest, IRequest<GetOutgoingOffersQueryResponse>
    {
        public int UserId { get; set; }
        public string? SearchByName { get; set; }
    }
}
