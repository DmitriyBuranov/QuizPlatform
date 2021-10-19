
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;

namespace QuizPlatformAPI.Models;
public class QuestionTypeRequestDto 
{
    public string Name{ get; set; }


    public QuestionTypeRequestDto()
    {

    }

    public QuestionTypeRequestDto(QuestionType QuestionType)
    {
        Name = QuestionType.Name;
    }
}
 