using QuizPlatform.Core.Domain.QuestionManagment;
using System.ComponentModel.DataAnnotations;

namespace QuizPlatformAPI.Models;
public class QuestionRequestDto 
{
    [Required]
    public string Description { get; set; }
    public Boolean WithTimer { get; set; }
    public int TimerInSeconds { get; set; }
    public Guid CategoryGuid { get; set; }
    public Guid QuestionTypeGuid { get; set; }

    public string Answer { get; set; }

    public string FirstVariant { get; set; }
    public string SecondVariant { get; set; }
    public string ThirdVariant { get; set; }
    public string FourthVariant { get; set; }
    public int RightVariant { get; set; }


    public QuestionRequestDto()
    {

    }

    public QuestionRequestDto(Question question)
    {
        Description = question.Description;
        WithTimer = question.WithTimer;
        TimerInSeconds = question.TimerInSeconds;
        CategoryGuid = question.CategoryGuid;
        QuestionTypeGuid = question.QuestionTypeGuid;
        Answer = question.Answer;
        FirstVariant = question.FirstVariant;
        SecondVariant = question.SecondVariant;
        ThirdVariant = question.ThirdVariant;
        FourthVariant = question.FourthVariant;
        RightVariant = question.RightVariant;
    }
}
 