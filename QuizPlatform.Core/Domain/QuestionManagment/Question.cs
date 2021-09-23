using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Core.Domain.QuestionManagment
{
    public class Question : BaseEntity
    {
        public string Description { get; set; }
        public Boolean WithTimer {  get; set; }
        public int TimerInSeconds { get; set; }
        public virtual Category Category {  get; set; }
        public Guid CategoryGuid { get; set; }

    }
}
