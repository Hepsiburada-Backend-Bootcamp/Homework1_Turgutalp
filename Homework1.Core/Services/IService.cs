using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework1.Core.Services
{
    public interface IService<TEntity> where TEntity : class
    {
        // Neden boyle bir service olusturduk ? 
        // Eger database degisirse mesela sqlserver to oracle tek yapmamiz gereken implementasyonu 
        // degistirmek
        
        
        // Id'ye gore urun cekilir.
        Task<TEntity> GetByIdAsync(int id);
        
        // ilgili modelin tumunu ceker
        Task<IEnumerable<TEntity>> GetAllAsync();
        
        
        // find(x=> x.id =23) ??
        // TEntity alan geriye bool donen metodu isaret eder.
        // herhangi bir parametreye gore ilgili nesneleri bulur
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);


        // category.SingleOrDefault(c=> c.name = "Macbook")
        // c => product veya category 
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);

    }
}