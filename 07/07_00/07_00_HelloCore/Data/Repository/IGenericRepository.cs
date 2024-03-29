﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HelloCore
{
    public interface IGenericRepository <TEntity> where TEntity : class
    {

        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        // De methode SearchKlant toevoegen

        //
        void Update(TEntity entity);
        void Delete(TEntity entity);

        IQueryable<TEntity> Search();
        //uitbreiding
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> voorwaarden);
        IEnumerable<TEntity> Find(params Expression<Func<TEntity, object>>[] includes);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>>? voorwaarden,
            params Expression<Func<TEntity, object>>[]? includes);

        void Save();
     }
}