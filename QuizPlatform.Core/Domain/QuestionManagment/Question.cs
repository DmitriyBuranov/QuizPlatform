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

        public string Answer { get; set; }

        public string FirstVariant{ get; set; }
        public string SecondVariant { get; set; }
        public string ThirdVariant { get; set; }
        public string FourthVariant { get; set; }
        public int RightVariant {  get; set; }


    }
}
