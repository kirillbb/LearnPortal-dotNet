﻿using LearnPortal.DAL.Data;
using LearnPortal.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LearnPortal.DAL.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity item)
        {
            await _dbSet.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity item)
        {
            _dbSet.Remove(item);
             await _context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(TEntity item)
        {
            _dbSet.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}