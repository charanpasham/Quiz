using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.RequestModels
{
    public class CategoryRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
