using FluentNHibernate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Interfaces.Repositories.Common
{
    public interface ICommandRepository<Entity> where Entity : class
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        void CloseTransaction();
        void Save(Entity entity);
        void Update(Entity entity);
        void Delete(int id);
    }
}
