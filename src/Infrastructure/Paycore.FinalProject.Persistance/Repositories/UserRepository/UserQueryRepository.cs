using FinalProject.Application.Interfaces.Repositories.UserRepositories;
using NHibernate;
using Paycore.FinalProject.Domain.Entities;
using Paycore.FinalProject.Persistance.Repositories.Common;

namespace Paycore.FinalProject.Persistance.Repositories.UserRepository
{
    public class UserQueryRepository : QueryRepository<User>, IUserQueryRepository
    {
        public UserQueryRepository(ISession session) : base(session)
        {
        }
    }
}
