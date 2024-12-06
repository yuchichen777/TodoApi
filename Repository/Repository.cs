
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Repository
{
     public class Repository<T> : IRepository<T> where T : class
     {
          private readonly DbContext _context;
          private readonly DbSet<T> _dbSet;
          public Repository(DbContext context)
          {
               _context = context;
               _dbSet = _context.Set<T>();
          }
          public async Task CreateAsnyc(T entity)
          {
               await _dbSet.AddAsync(entity);
               await _context.SaveChangesAsync();
          }

          public async Task DeleteAsnyc(int id)
          {
               var entity = await _dbSet.FindAsync(id);
               if (entity != null)
               {
                    _dbSet.Remove(entity);
                    await _context.SaveChangesAsync();
               }
          }

          public async Task<T> FindByIdAsnyc(int id)
          {
               return await _dbSet.FindAsync(id);
          }

          public async Task<IEnumerable<T>> GetAllAsnyc()
          {
               return await _dbSet.ToListAsync();
          }

          public async Task UpdateAsnyc(T entity)
          {
               _dbSet.Update(entity);
               await _context.SaveChangesAsync();
          }
     }
}
