using System;

namespace QuizPlatform.Core.Domain.QuestionManagment
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public Boolean WithTimer {  get; set; }
        public int TimerInSeconds { get; set; }
        public virtual Category Category {  get; set; }
        public Guid CategoryGuid { get; set; }
        public virtual QuestionType QuestionType {  get; set; }
        public Guid QuestionTypeGuid { get; set; }

    }
}
