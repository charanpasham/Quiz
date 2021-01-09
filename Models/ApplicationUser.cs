using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Quiz.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<QuizTaken> QuizTaken { get; set; }
        public ICollection<Quiz> Quiz { get; set; }
    }
}
