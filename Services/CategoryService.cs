using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Supermarket.API_new.Domain.Models;
using Supermarket.API_new.Domain.Repositories;
using Supermarket.API_new.Domain.Services;
using Supermarket.API_new.Domain.Services.Communication;

namespace Supermarket.API_new.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Category>> ListAsync()
        {
            //use repository pattern to handle data acess to and from db
            return await _categoryRepository.ListAsync();
        }

        public async Task<SaveCategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new SaveCategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new SaveCategoryResponse($"An error occurred when saving the category: { ex.Message }");
            }
        }
    }
}