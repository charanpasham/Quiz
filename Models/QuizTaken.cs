using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Quiz.Enums;

namespace Quiz.Models
{
    public class QuizTaken
    {
        public int QuizTakenId { get; set; }
        public QuizStatus QuizStatus { get; set; }
        public int Score { get; set; }


        public ICollection<QuizResponse> QuizResponses { get; set; }
    }
}
