using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Core.Abstractions.Repositories
{
    public interface IQuestionRepository<T> where T : Question
    {
        Task<IEnumerable<T>> GetAmountInCategoryAsync(int num, Guid categoryGuid);

    }
}
