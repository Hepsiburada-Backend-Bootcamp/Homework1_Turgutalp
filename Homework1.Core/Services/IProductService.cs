using System.Threading.Tasks;
using Homework1.Core.Entity;

namespace Homework1.Core.Services
{
    public interface IProductService: IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}