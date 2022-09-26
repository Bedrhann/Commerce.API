using FinalProject.Application.Interfaces.Repositories.CategoryRepositories;
using FinalProject.Application.Interfaces.Repositories.Common;
using NHibernate;
using Paycore.FinalProject.Domain.Entities;
using Paycore.FinalProject.Persistance.Repositories.Common;

namespace Paycore.FinalProject.Persistance.Repositories.CategoryRepositories
{
    public class CategoryQueryRepository : QueryRepository<Category>, ICategoryQueryRepository
    {
        public CategoryQueryRepository(ISession session) : base(session)
        {

        }
    }
}
