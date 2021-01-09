using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class Quiz
    {
        public  int QuizId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Score { get; set; }


        public ICollection<QuizTaken> QuizTaken { get; set; }

        public ICollection<QuizQuestion> QuizQuestions { get; set; }
    }
}
