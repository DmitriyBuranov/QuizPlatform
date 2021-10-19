
using QuizPlatform.Core.Domain.QuestionManagment;
using QuizPlatformAPI.Models;

namespace QuizPlatformAPI.Mappers;
public static class QuestionTypeMapper
{
    public static QuestionType MapFromModel(QuestionTypeRequestDto request, QuestionType QuestionType = null)
    {
        if (QuestionType == null)
            QuestionType = new QuestionType();

        QuestionType.Name = request.Name;
 
        return QuestionType;
    }
}
