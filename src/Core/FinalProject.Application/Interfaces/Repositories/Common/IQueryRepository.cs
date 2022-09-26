using System.Linq.Expressions;

namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface IQueryRepository<Entity> where Entity : class
    {
        List<Entity> GetAll();
        Entity GetById(int id);
        IEnumerable<Entity> Find(Expression<Func<Entity, bool>> expression);
        IEnumerable<Entity> Where(Expression<Func<Entity, bool>> where);
        IQueryable<Entity> Entities { get; }

    }
}
