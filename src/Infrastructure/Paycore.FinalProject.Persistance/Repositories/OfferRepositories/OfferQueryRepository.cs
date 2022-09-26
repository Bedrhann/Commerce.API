using FinalProject.Application.Interfaces.Repositories.OfferRepositories;
using NHibernate;
using Paycore.FinalProject.Domain.Entities;
using Paycore.FinalProject.Persistance.Repositories.Common;

namespace Paycore.FinalProject.Persistance.Repositories.OfferRepositories
{
    public class OfferQueryRepository : QueryRepository<Offer>, IOfferQueryRepository
    {
        public OfferQueryRepository(ISession session) : base(session)
        {
        }
    }
}
