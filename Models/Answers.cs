using System.Collections.Generic;

namespace Quiz.Models
{
    public class Answers
    {
        public int AnswersId { get; set; }
        public string Option { get; set; }
        public bool IsRight { get; set; }

        public ICollection<Response> QuizResponse { get; set; }
    }
}
