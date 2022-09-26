using FinalProject.Application.Interfaces.Repositories.Common;
using NHibernate;
using System.Linq.Expressions;

namespace Paycore.FinalProject.Persistance.Repositories.Common
{
    public class QueryRepository<Entity> : IQueryRepository<Entity> where Entity : class
    {

        private readonly ISession _session;
        private ITransaction transaction;

        public QueryRepository(ISession session)
        {
            _session = session;
        }
        public IQueryable<Entity> Entities => _session.Query<Entity>();

        public IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression)
        {
            return _session.Query<Entity>().Where(expression).ToList();
        }

        public List<Entity> GetAll()
        {
            return _session.Query<Entity>().ToList();
        }

        public Entity GetById(int id)
        {
            var entity = _session.Get<Entity>(id);
            return entity;
        }

        public IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where)
        {
            return _session.Query<Entity>().Where(where).AsQueryable();
        }
    }
}
