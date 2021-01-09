using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Quiz.Models
{
    public class QuizAnswers
    {
        public int QuizAnswersId { get; set; }
        public string Option { get; set; }
        public bool IsRight { get; set; }

        public ICollection<QuizResponse> QuizResponse { get; set; }
    }
}
