using System.Threading.Tasks;
using Homework1.Core.Entity;
using Homework1.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private HomeworkDbContext homeworkDbContext => _context as HomeworkDbContext;

        public ProductRepository(HomeworkDbContext context) : base(context)
        {
        }
        
        // Bir id verilecek bu id product donerken ayrica product'in kategorisini de donecek.
        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await homeworkDbContext.Products.Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == productId);
            
        }
    }
}