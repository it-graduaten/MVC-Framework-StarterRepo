using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _09_00_HelloCore
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> voorwaarden,
                              params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> voorwaarden);
        IEnumerable<TEntity> Find(params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Search();
        void Update(TEntity entity);
        void Delete(TEntity entity);
     }
}