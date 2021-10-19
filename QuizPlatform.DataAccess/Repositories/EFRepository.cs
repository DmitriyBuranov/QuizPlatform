using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatform.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.DataAccess.Repositories
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {

        protected readonly DataContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public EFRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }



        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
