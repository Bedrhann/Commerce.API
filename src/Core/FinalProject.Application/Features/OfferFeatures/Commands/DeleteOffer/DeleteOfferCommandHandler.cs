using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;

namespace FinalProject.Application.Features.OfferFeatures.Commands.DeleteOffer
{
    public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommandRequest, BaseResponse<OfferDto>>
    {
        private readonly IOfferCommandRepository _commandRepository;
        private readonly IOfferQueryRepository _queryRepository;
        public DeleteOfferCommandHandler(IOfferCommandRepository repository, IOfferQueryRepository queryRepository)
        {
            _commandRepository = repository;
            _queryRepository = queryRepository;
        }
        public async Task<BaseResponse<OfferDto>> Handle(DeleteOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Offer product = _queryRepository.GetById(request.Id);
                if (product is null)
                {
                    return new BaseResponse<OfferDto>("Record Not Found");
                }

                _commandRepository.BeginTransaction();
                _commandRepository.Delete(request.Id);
                _commandRepository.Commit();
                _commandRepository.CloseTransaction();

                return new BaseResponse<OfferDto>(product.Adapt<OfferDto>());
            }
            catch (Exception ex)
            {
                Log.Error("DeleteOfferCommandHandler", ex);
                _commandRepository.Rollback();
                _commandRepository.CloseTransaction();
                return new BaseResponse<OfferDto>(ex.Message);
            }
        }
    }
}
