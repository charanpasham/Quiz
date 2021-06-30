using System.Collections.Generic;
using Quiz.Enums;

namespace Quiz.Models
{
    public class Taken
    {
        public int TakenId { get; set; }
        public QuizStatus QuizStatus { get; set; }
        public int Score { get; set; }


        public ICollection<Response> Responses { get; set; }
    }
}
