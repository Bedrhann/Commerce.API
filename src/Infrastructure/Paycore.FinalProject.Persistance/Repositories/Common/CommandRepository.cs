using FinalProject.Application.Interfaces.Repositories.Common;
using NHibernate;

namespace Paycore.FinalProject.Persistance.Repositories.Common
{
    public class CommandRepository<Entity> : ICommandRepository<Entity> where Entity : class
    {
        private readonly ISession _session;
        private ITransaction transaction;

        public CommandRepository(ISession session)
        {
            _session = session;
        }

        public void BeginTransaction()
        {
            transaction = _session.BeginTransaction();
        }

        public void CloseTransaction()
        {
            if (transaction != null)
            {
                transaction.Dispose();
                transaction = null;
            }
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void Delete(int id)
        {
            var entity = _session.Get<Entity>(id); ;
            if (entity != null)
            {
                _session.Delete(entity);
            }
        }

        public void Rollback()
        {
            transaction.Rollback();
        }

        public void Save(Entity entity)
        {
            _session.Save(entity);
        }

        public void Update(Entity entity)
        {
            _session.Update(entity);
        }
    }
}
