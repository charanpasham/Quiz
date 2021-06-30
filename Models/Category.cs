using System.Collections.Generic;


namespace Quiz.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string QuizCategoryType { get; set; }

        public ICollection<Questions> Question { get; set; }
        public ICollection<Answers> QuizAnswers { get; set; }
        public ICollection<Response> QuizResponse { get; set; }
        public ICollection<Quizes> Quiz { get; set; }
    }
}
