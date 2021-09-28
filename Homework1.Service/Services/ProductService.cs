using System.Threading.Tasks;
using Homework1.Core.Entity;
using Homework1.Core.Repositories;
using Homework1.Core.Services;
using Homework1.Core.UnitOfWork;

namespace Homework1.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.ProductRepository.GetWithCategoryByIdAsync(productId);
        }
    }
}
