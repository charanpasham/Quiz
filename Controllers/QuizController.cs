using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz.Data;
using Quiz.Models;
using Quiz.RequestModels;
using Quiz.ResponseModels;

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
        [HttpGet]
        public async Task<IEnumerable<CategoryResponse>> Get(int limit = 10, int offset = 0)
        {
            var categoryResponse = new List<CategoryResponse>();
            var categories = await _context.Category.
                             OrderBy(cat => cat.QuizCategoryType)
                             .Skip(offset)
                             .Take(limit)
                             .ToListAsync();
            foreach (var category in categories)
            {
                categoryResponse.Add(new CategoryResponse()
                {
                    Id = category.CategoryId,
                    Name = category.QuizCategoryType,
                });
            }
            return categoryResponse;
        }

        // POST api/<controller>
        [HttpPost("quiz")]
        public void Post([FromBody] QuizRequest quizRequest)
        {
            var quiz = new Quizes
            {
                Title = quizRequest.Title,
                Summary = quizRequest.Summary,
                Score = quizRequest.Score,
                // Exception handler will kick off when trying to insert the categoryId's that doesn't exist.
                CategoryId = quizRequest.CategoryId,
            };
            _context.Quizes.Add(quiz);
            _context.SaveChanges();
        }

        // GET: api/<controller>
        [HttpGet("CategoryById")]
        public CategoryResponse QuizById(int categoryId)
        {
            var category = _context.Category.FirstOrDefault(qc => qc.CategoryId == categoryId);
            return new CategoryResponse
            {
                Id = category.CategoryId,
                Name = category.QuizCategoryType,
            };
        }


        // DELETE api/<controller>/5
        [HttpDelete("deleteQuiz/{id}")]
        public void DeleteQuiz(int id)
        {
            var foundQuiz = _context.Quizes.FirstOrDefault(quiz => quiz.QuizesId == id);
            if (foundQuiz != null)
            {
                _context.Quizes.Remove(foundQuiz);
            }
        }
    }
}
