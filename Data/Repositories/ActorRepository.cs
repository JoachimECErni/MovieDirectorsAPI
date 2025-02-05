using Microsoft.EntityFrameworkCore;
using MovieDirectorsAPI.Data.Context;
using MovieDirectorsAPI.Data.Contracts;
using MovieDirectorsAPI.Data.Entity;
using MovieDirectorsAPI.Data.Repositories.Interfaces;
using System.Linq.Expressions;

namespace MovieDirectorsAPI.Data.Repositories
{
    public class ActorRepository<T> : IActorRepository<T> where T : Actor
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public ActorRepository(AppDbContext context)
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
            return await _dbset.Include(a => a.ActorMovies)
            .ThenInclude(am => am.Movie)
            .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            var results = await _dbset.Include(a => a.ActorMovies)
                .ThenInclude(am => am.Movie)
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
