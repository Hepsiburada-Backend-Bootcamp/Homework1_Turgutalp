using System.Threading.Tasks;
using Homework1.Core.Entity;

namespace Homework1.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);


    }
}