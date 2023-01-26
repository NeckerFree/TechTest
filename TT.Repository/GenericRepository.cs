﻿using Microsoft.EntityFrameworkCore;
using TT.DataAccess.Data;
using TT.Domain.Interfaces;

namespace TT.Repository
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly GamesContext _dbContext;

        protected GenericRepository(GamesContext context)
        {
            _dbContext = context;
        }

        public async Task Add(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T> Get(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbContext.Set<T>().FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }
    }
}
