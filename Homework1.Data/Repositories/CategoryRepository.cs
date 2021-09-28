using System.Threading.Tasks;
using Homework1.Core.Entity;
using Homework1.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Homework1.Data.Repositories
{
    public class CategoryRepository: Repository<Category>,ICategoryRepository
    {
        private HomeworkDbContext _homeworkDbContext => _context as HomeworkDbContext;
        public CategoryRepository(HomeworkDbContext context) : base(context)
        {
        }

        // id verilir, hem o kategori hemde kategorinin oldugu productlar donulurr.
        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {

            return await _homeworkDbContext.Categories.Include(x => x.Products)
                .SingleOrDefaultAsync(x => x.Id == categoryId);

        }
    }
}