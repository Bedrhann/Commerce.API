using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.DTOs.Product;
using FinalProject.Application.Features.ProductFeatures.Commands.UpdateProduct;
using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.OfferFeatures.Commands.CreateOffer
{
    public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommandRequest, BaseResponse<OfferCreateDto>>
    {
        private readonly IOfferCommandRepository _offerCommandRepository;
        private readonly IUserQueryRepository _userQueryRepository;
        private readonly IProductQueryRepository _productQueryRepository;
        private readonly IMediator _mediator;

        public CreateOfferCommandHandler(IOfferCommandRepository repository, IUserQueryRepository userQueryRepository, IProductQueryRepository productQueryRepository, IMediator mediator)
        {
            _offerCommandRepository = repository;
            _userQueryRepository = userQueryRepository;
            _productQueryRepository = productQueryRepository;
            _mediator = mediator;
        }
        public async Task<BaseResponse<OfferCreateDto>> Handle(CreateOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Offer newOffer = request.OfferDto.Adapt<Offer>();
                User user = _userQueryRepository.GetById(request.OfferDto.BuyerId);
                if (user is null)
                {
                    return new BaseResponse<OfferCreateDto>("User Not Found");
                }
                Product product = _productQueryRepository.GetById(request.OfferDto.ProductId);
                if (product is null)
                {
                    return new BaseResponse<OfferCreateDto>("Product Not Found");
                }
                if (!product.IsOfferable || product.IsSold)
                {
                    return new BaseResponse<OfferCreateDto>("You cannot offer on this product");
                }
               
                if (newOffer.OfferPrice == product.Price)//eğer ürüne fiyatına eşit bir teklif geldiyse ürünün satışını gerçekleştiriyoruz.
                {
                    product.IsSold = true;
                    product.IsOfferable = false;
                    ProductDto productDto = product.Adapt<ProductDto>();
                    UpdateProductCommandRequest updateProductCommandRequest = new UpdateProductCommandRequest()
                    {
                        ProductDto = productDto,
                    };
                    await _mediator.Send(updateProductCommandRequest);//Geçerli ürünün IsSold alanını true yaparak güncelliyoruz.
                    return new BaseResponse<OfferCreateDto>("The product has been successfully sold", true);
                }
                newOffer.User = user;
                newOffer.Product = product;

                _offerCommandRepository.BeginTransaction();
                _offerCommandRepository.Save(newOffer);
                _offerCommandRepository.Commit();
                _offerCommandRepository.CloseTransaction();

                return new BaseResponse<OfferCreateDto>(request.OfferDto);
            }
            catch (Exception ex)
            {
                Log.Error("CreateOfferCommandHandler", ex);
                _offerCommandRepository.Rollback();
                _offerCommandRepository.CloseTransaction();
                return new BaseResponse<OfferCreateDto>(ex.Message);
            }
        }
    }
}
