using System.Threading.Tasks;
using Homework1.Core.Entity;

namespace Homework1.Core.Services
{
    public interface ICategoryService: IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}