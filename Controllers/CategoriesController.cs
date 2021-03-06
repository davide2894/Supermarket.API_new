using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Domain.Services;
using AutoMapper;
using Supermarket.API_new.Resources;
using Supermarket.API_new.Extensions;

namespace Supermarket.API_new.Controllers
{
    [Route("/api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryResource>> GetAllCategoriesAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource saveCategoryResouce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(saveCategoryResouce);

            var saveCategoryResponse = await _categoryService.SaveAsync(category);
            
            if(!saveCategoryResponse.Success)
            {
                return BadRequest(saveCategoryResponse.Message);
            }

            // category saving process to db was successfull

            var categoryResource = _mapper.Map<Category, CategoryResource>(category);

            return Ok(categoryResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource saveCategoryResouce)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCategoryResource, Category>(saveCategoryResouce);
            
            var result = await _categoryService.UpdateAsync(id, category);

            if(!result.Success)
            {
                return BadRequest(result.Message);
            }

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.ResponseCategory);

            return Ok(categoryResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleteResult = await _categoryService.DeleteAsync(id);

            if(!deleteResult.Success)
            {
                return BadRequest(deleteResult.Message);
            }

            var deletedCategoryResource = _mapper.Map<Category, CategoryResource>(deleteResult.ResponseCategory);

            return Ok(deletedCategoryResource);
        }
    }
}