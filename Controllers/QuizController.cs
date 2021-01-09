using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data;
using Quiz.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string _userId;

        public QuizController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor _httpContext)
        {
            _context = context;
            _userManager = userManager;
            this._httpContext = _httpContext;
            _userId = userManager.GetUserId(_httpContext.HttpContext.User);
        }
        // GET: api/<controller>
        [HttpGet("category")]
        public  IEnumerable<QuizCategory> Get()
        {
            var userId = _userId;
            return _context.QuizCategory.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        // [HttpPost("category")]
        // public void Post([FromBody]QuizCategory category)
        // {
        //     _context.QuizCategory.Add(category);
        //     _context.SaveChanges();
        // }


        // POST api/<controller>
        [HttpPost("quiz")]
        public void Post([FromBody]Quiz.Models.Quiz quiz)
        {
            _context.Quiz.Add(quiz);
            _context.SaveChanges();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("deleteCategory/{id}")]
        public void DeleteCategory(int id)
        {
            var foundCategory = _context.QuizCategory.FirstOrDefault(category => category.QuizCategoryId == id);
            if (foundCategory != null)
            {
                _context.QuizCategory.Remove(foundCategory);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("deleteQuiz/{id}")]
        public void DeleteQuiz(int id)
        {
            var foundQuiz = _context.Quiz.FirstOrDefault(quiz => quiz.QuizId == id);
            if (foundQuiz != null)
            {
                _context.Quiz.Remove(foundQuiz);
            }
        }
    }
}
