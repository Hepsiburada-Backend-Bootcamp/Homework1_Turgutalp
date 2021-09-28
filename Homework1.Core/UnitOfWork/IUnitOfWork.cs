using System.Threading.Tasks;
using Homework1.Core.Repositories;

namespace Homework1.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        
        ICategoryRepository CategoryRepository { get; }
        
        Task CommitAsync();

        void Commit();
        
    }
}