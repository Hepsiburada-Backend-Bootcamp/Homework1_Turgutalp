using System.Threading.Tasks;
using Homework1.Core.Repositories;
using Homework1.Core.UnitOfWork;
using Homework1.Data.Repositories;

namespace Homework1.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HomeworkDbContext _context;
        private ProductRepository _productRepository;
        private CategoryRepository _categoryRepository;


        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository(_context);

        public ICategoryRepository CategoryRepository =>
            _categoryRepository ??= new CategoryRepository(_context);
    

        public UnitOfWork(HomeworkDbContext homeworkDbContext)
        {
            _context = homeworkDbContext;
        }

        public async  Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        // means SaveChanges();
        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}