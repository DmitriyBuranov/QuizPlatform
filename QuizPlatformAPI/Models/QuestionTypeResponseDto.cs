
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;

namespace QuizPlatformAPI.Models;
public class QuestionTypeResponseDto : BaseEntity 
{
    public string Name{ get; set; }


    public QuestionTypeResponseDto()
    {

    }

    public QuestionTypeResponseDto(QuestionType QuestionType)
    {
        Id = QuestionType.Id;
        Name = QuestionType.Name;
    }
}
 