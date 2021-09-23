
using QuizPlatform.Core.Domain;
using QuizPlatform.Core.Domain.QuestionManagment;

namespace QuizPlatformAPI.Models;
public class QuestionRequestDto : BaseEntity
{
    public string Description { get; set; }
    public Boolean WithTimer { get; set; }
    public int TimerInSeconds { get; set; }
    public Guid CategoryGuid { get; set; }

    public QuestionRequestDto()
    {

    }

    /// <summary>
    /// Constuctor
    /// </summary>
    /// <param name="question">question</param>
    public QuestionRequestDto(Question question)
    {
        Id = question.Id;
        Description = question.Description;
        WithTimer = question.WithTimer;
        TimerInSeconds = question.TimerInSeconds;
        CategoryGuid = question.CategoryGuid;
    }
}
 