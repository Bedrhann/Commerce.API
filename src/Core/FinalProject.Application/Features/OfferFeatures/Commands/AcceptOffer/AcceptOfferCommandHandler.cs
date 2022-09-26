using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.OfferFeatures.Commands.AcceptOffer
{
    public class AcceptOfferCommandHandler : IRequestHandler<AcceptOfferCommandRequest, BaseResponse<OfferDto>>
    {
        private readonly IOfferQueryRepository _offerQueryRepository;
        private readonly IOfferCommandRepository _offerCommandRepository;
        private readonly IProductCommandRepository _productCommandRepository;

        public AcceptOfferCommandHandler(IOfferQueryRepository offerQueryRepository, IOfferCommandRepository offerCommandRepository, IProductCommandRepository productCommandRepository)
        {
            _offerQueryRepository = offerQueryRepository;
            _offerCommandRepository = offerCommandRepository;
            _productCommandRepository = productCommandRepository;
        }

        public async Task<BaseResponse<OfferDto>> Handle(AcceptOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Offer offer = _offerQueryRepository.GetById(request.OfferId);
                if (offer is null)
                {
                    return new BaseResponse<OfferDto>("Record Not Found");
                }
                if (offer.Product.User.Id != request.OwnerId)
                {
                    return new BaseResponse<OfferDto>("unauthorized action");
                }
                offer.Product.IsSold = true;
                offer.OfferStatus = "Accepted";
                _offerCommandRepository.BeginTransaction();
                _offerCommandRepository.Update(offer);
                _offerCommandRepository.Commit();
                _offerCommandRepository.CloseTransaction();

                offer.BuyerId = offer.User.Id;//veritabanından gelen verilerin ilişkili tablolardan ıd nesnelerini alıp gerekli değerlere atamalarını yapıyoruz
                offer.ProductId = offer.Product.Id;

                return new BaseResponse<OfferDto>(offer.Adapt<OfferDto>());
            }
            catch (Exception ex)
            {
                Log.Error("AcceptOfferCommandHandler", ex);
                _offerCommandRepository.Rollback();
                _offerCommandRepository.CloseTransaction();
                return new BaseResponse<OfferDto>(ex.Message);
            }
        }
    }
}
