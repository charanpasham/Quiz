using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Quiz.Models
{
    public class QuizCategory
    {
        public int QuizCategoryId { get; set; }
        public string QuizCategoryType { get; set; }

        public ICollection<QuizQuestion> QuizQuestion { get; set; }
        public ICollection<QuizAnswers> QuizAnswers{ get; set; }
        public ICollection<QuizResponse> QuizResponse { get; set; }
        public ICollection<Quiz> Quiz{ get; set; }
    }
}
