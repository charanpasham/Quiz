using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Quiz.Data;
using Quiz.Models;
using Quiz.ResponseModels;
using Quiz.RequestModels;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Quiz.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
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

        // GET: api/<controller>
        [ProducesResponseType(typeof(CategoryResponse), 201)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        [HttpPost]
        public async Task<ActionResult<CategoryResponse>> Post([FromBody] CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _context.Category.FirstOrDefault(category => category.QuizCategoryType.Equals(categoryRequest.Name));

            // This mean category already exists, do not add it again, return an exception.
            if (category != null)
            {
                throw new Exception($"Category type {categoryRequest.Name} already exist!");
            }

            var categoryEntity = new Category
            {
                QuizCategoryType = categoryRequest.Name,
            };

            _context.Category.Add(categoryEntity);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryEntity.CategoryId }, GetCategoryById(categoryEntity.CategoryId));
        }

        // GET: api/<controller>
        [HttpPatch]
        public async Task<ActionResult<CategoryResponse>> PatchById(int id, CategoryRequest categoryUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _context.Category.FirstOrDefault(category => category.CategoryId == id);

            // This mean category already exists, do not add it again, return an exception.
            if (category == null)
            {
                throw new Exception($"Category Id doesn't exist");
            }

            category.QuizCategoryType = categoryUpdateRequest.Name;

            await _context.SaveChangesAsync();
            return GetCategoryById(category.CategoryId);
        }

        // GET: api/<controller>
        [HttpGet("CategoryById")]
        public CategoryResponse GetCategoryById(int categoryId)
        {
            var category = _context.Category.FirstOrDefault(qc => qc.CategoryId == categoryId);
            return new CategoryResponse
            {
                Id = category.CategoryId,
                Name = category.QuizCategoryType,
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("DeleteCategory/{id}")]
        public void Delete(int id)
        {
            var foundCategory = _context.Category.FirstOrDefault(category => category.CategoryId == id);
            if (foundCategory != null)
            {
                _context.Category.Remove(foundCategory);
            }
            _context.SaveChanges();
        }

    }
}
