using Microsoft.EntityFrameworkCore;
using MovieDirectorsAPI.Data.Context;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MovieDirectorsAPI.Data.Repositories
{
    public class DirectorRepository<T> : IDirectorRepository<T> where T : Director
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public DirectorRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(int id)
        {
            var entity = await _dbset.FindAsync(id);
            if (entity != null)
            {
                _dbset.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<T> Get(int id)
        {
            return await _dbset.Include(d => d.Movies)
            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            var results = await _dbset.Include(d => d.Movies)
                .ToListAsync();

            return results;
        }

        public async Task<T> Update(T entity)
        {
            _dbset.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
