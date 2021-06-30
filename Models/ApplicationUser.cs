using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Quiz.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Taken> Taken { get; set; }
        public ICollection<Quizes> Quiz { get; set; }
    }
}
