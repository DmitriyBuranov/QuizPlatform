using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPlatform.Core.Domain.QuestionManagment
{
    public class Question
    {
        public string Description { get; set; }

        public Boolean WithTimer {  get; set; }

        public int TimerInSeconds { get; set; }
        public Category Category {  get; set; }
    }
}
