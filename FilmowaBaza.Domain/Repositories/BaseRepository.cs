using FilmowaBaza.Domain.Repositories.Interfaces;
using FilmowaBaza.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FilmowaBaza.Domain.Exceptions;

namespace FilmowaBaza.Domain.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity<long>
    {
        private readonly AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow;
            await _context.AddAsync(entity);
            await SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            if (entity == null)
                throw new AppException(ErrorCode.NotFound);

            await Task.FromResult(_dbSet.Remove(entity));
            await SaveChangesAsync();
        }
        public async Task<IList<T>> GetAllAsListAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetAsyncById(long id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result == null)
            {
                throw new AppException(ErrorCode.NotFound);
            }
            return result; 
        }
        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsQueryable();
        }
        public async Task UpdateAsync(T entity)
        {
            if (entity == null) 
            {
                throw new AppException(ErrorCode.NotFound);
            }
            entity.ModifiedAt = DateTime.UtcNow;
            await Task.FromResult(_dbSet.Update(entity));

            await SaveChangesAsync();
        }
        public async Task SaveChangesAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new AppException(new ErrorCode("Error saving changes",System.Net.HttpStatusCode.Conflict));
            }
        }
    }
}
