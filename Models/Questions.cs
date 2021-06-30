using System.Collections.Generic;

namespace Quiz.Models
{
    public class Questions
    {
        public int QuestionsId { get; set; }
        public string Question { get; set; }
        public bool Active { get; set; }

        public ICollection<Answers> Answers { get; set; }

        public ICollection<Response> Response { get; set; }
    }
}
