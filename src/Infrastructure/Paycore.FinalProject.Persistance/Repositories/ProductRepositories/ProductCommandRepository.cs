using FinalProject.Application.Interfaces.Repositories.ProductRepositories;
using NHibernate;
using Paycore.FinalProject.Domain.Entities;
using Paycore.FinalProject.Persistance.Repositories.Common;

namespace Paycore.FinalProject.Persistance.Repositories.ProductRepositories
{
    public class ProductCommandRepository : CommandRepository<Product>, IProductCommandRepository
    {
        public ProductCommandRepository(ISession session) : base(session)
        {
        }
    }
}
