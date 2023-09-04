using _09_00_HelloCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace _09_00_HelloCore
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class { 
        private readonly HelloCoreContext _context;
        public GenericRepository(HelloCoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            try
            {
                await _context.Set<TEntity>().AddAsync(entity);
            } catch (Exception e)
            {
                throw new Exception(""+ e.Message);
            }
        }
        
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? voorwaarden,
                              params Expression<Func<TEntity, object>>[]? includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes != null)
            {
                foreach (var item in includes)
                {
                    query = query.Include(item);
                }
            }
            if (voorwaarden != null)
            {
                query = query.Where(voorwaarden);
            }
            return query.ToList();
        }


        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? voorwaarden)
        {
            return Find(voorwaarden, null).ToList();
        }

        public IEnumerable<TEntity> Find(params Expression<Func<TEntity, object>>[]? includes)
        {
            return Find(null, includes).ToList();
        }

        public IQueryable<TEntity> Search()
        {
            return _context.Set<TEntity>().AsQueryable();
        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

    }
}
