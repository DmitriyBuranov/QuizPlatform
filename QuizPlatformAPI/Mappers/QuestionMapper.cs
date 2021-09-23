
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Mappers;
public static class QuestionMapper
{
    public static Question MapFromModel(QuestionRequestDto request, Question question = null, Category category = null)
    {
        if (question == null)
            question = new Question();

        question.CategoryGuid = category != null ? category.Id : request.CategoryGuid;
        question.Description = request.Description;
        question.WithTimer = request.WithTimer;
        question.TimerInSeconds = request.TimerInSeconds;
 
        return question;
    }
}
