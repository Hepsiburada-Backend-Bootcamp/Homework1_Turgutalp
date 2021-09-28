using System.Threading.Tasks;
using Homework1.Core.Entity;

namespace Homework1.Core.Repositories
{
    public interface IProductRepository: IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}