using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using NHibernate;
using Paycore.FinalProject.Domain.Entities;
using Paycore.FinalProject.Persistance.Repositories.Common;

namespace Paycore.FinalProject.Persistance.Repositories.OfferRepositories
{
    public class OfferCommandRepository : CommandRepository<Offer>, IOfferCommandRepository
    {
        public OfferCommandRepository(ISession session) : base(session)
        {
        }
    }
}
