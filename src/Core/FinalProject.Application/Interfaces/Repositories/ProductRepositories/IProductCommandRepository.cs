using FinalProject.Application.Interfaces.Repositories.Common;
using Paycore.FinalProject.Domain.Entities;

namespace FinalProject.Application.Interfaces.Repositories.ProductRepositories
{
    public interface IProductCommandRepository : ICommandRepository<Product>
    {
    }
}
