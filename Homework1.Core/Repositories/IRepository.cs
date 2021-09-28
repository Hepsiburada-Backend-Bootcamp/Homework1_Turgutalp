using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Homework1.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity:class
    {
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

       Task AddAsync(TEntity entity);

       Task AddRangeAsync(IEnumerable<TEntity> entities);

       void Remove(TEntity entities);

       void RemoveRange(IEnumerable<TEntity> entity);

       TEntity Update(TEntity entity);





    }
}