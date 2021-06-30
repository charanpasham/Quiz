using System.Collections.Generic;

namespace Quiz.Models
{
    public class Quizes
    {
        public int QuizesId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int Score { get; set; }
        public int CategoryId { get; set; }


        public ICollection<Taken> Taken { get; set; }

        public ICollection<Questions> Questions { get; set; }
    }
}
