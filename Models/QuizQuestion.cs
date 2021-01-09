using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizQuestion
    {
        public int QuizQuestionId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }

        public ICollection<QuizAnswers> QuizAnswers { get; set; }

        public ICollection<QuizResponse> QuizResponse { get; set; }
    }
}
