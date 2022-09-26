using FinalProject.Application.DTOs.Offer;
using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using FinalProject.Application.Wrappers.Response;
using Mapster;
using MediatR;
using Paycore.FinalProject.Domain.Entities;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Features.OfferFeatures.Commands.UpdateOffer
{
    public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommandRequest, BaseResponse<OfferDto>>
    {
        private readonly IOfferCommandRepository _commandRepository;
        private readonly IOfferQueryRepository _queryRepository;
        public UpdateOfferCommandHandler(IOfferCommandRepository repository, IOfferQueryRepository queryRepository)
        {
            _commandRepository = repository;
            _queryRepository = queryRepository;
        }
        public async Task<BaseResponse<OfferDto>> Handle(UpdateOfferCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                Offer product = _queryRepository.GetById(request.OfferUpdateDto.Id);
                if (product is null)
                {
                    return new BaseResponse<OfferDto>("Record Not Found");
                }
                request.OfferUpdateDto.Adapt<OfferUpdateDto, Offer>(product);
                _commandRepository.BeginTransaction();
                _commandRepository.Update(product);
                _commandRepository.Commit();
                _commandRepository.CloseTransaction();

                return new BaseResponse<OfferDto>(request.OfferUpdateDto.Adapt<OfferDto>());
            }
            catch (Exception ex)
            {
                Log.Error("UpdateOfferCommandHandler", ex);
                _commandRepository.Rollback();
                _commandRepository.CloseTransaction();
                return new BaseResponse<OfferDto>(ex.Message);
            }
        }
    }
}
