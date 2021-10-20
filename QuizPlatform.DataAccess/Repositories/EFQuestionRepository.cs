using Microsoft.EntityFrameworkCore;
using QuizPlatform.Core.Abstractions.Repositories;
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatform.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.DataAccess.Repositories
{
    public class EFQuestionRepository<T>: IQuestionRepository<T> where T : Question
    {
        protected readonly DataContext _dbContext;

        private readonly DbSet<T> _dbSet;

        public EFQuestionRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAmountInCategoryAsync(int num,Guid categoryGuid)
        {
            Random rnd = new();
            var WithCategory = await _dbSet.Where(x => x.CategoryGuid == categoryGuid).ToListAsync();
            var AmountWithCategory = WithCategory.OrderBy(x => rnd.Next(1, WithCategory.Count - 1)).Take(num);

            return  AmountWithCategory;
        }
    }
}
