using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.RequestModels
{
    public class QuizRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Summary { get; set; }

        [Required]
        public int Score { get; set; }

        public int CategoryId { get; set; }
    }
}
