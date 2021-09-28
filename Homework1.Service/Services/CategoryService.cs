using System.Threading.Tasks;
using Homework1.Core.Entity;
using Homework1.Core.Repositories;
using Homework1.Core.Services;
using Homework1.Core.UnitOfWork;

namespace Homework1.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.CategoryRepository.GetWithProductsByIdAsync(categoryId);
        }
    }
}