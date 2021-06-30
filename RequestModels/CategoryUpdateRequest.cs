using System;
using System.ComponentModel.DataAnnotations;

namespace Quiz.RequestModels
{
    public class CategoryUpdateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}
