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

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(category);
            }
            catch (Exception ex)
            {
                // Do some logging stuff
                return new CategoryResponse($"An error occurred when saving the category: { ex.Message }");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);

            if(existingCategory == null)
            {
                return new CategoryResponse("Category not found");
            }

            existingCategory.Name = category.Name;

            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategory);
            } 
            catch (Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: { ex.Message }");
            }

        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategoryToDelete = await _categoryRepository.FindByIdAsync(id);

            if (existingCategoryToDelete == null)
            {
                return new CategoryResponse("Category not found");
            }

            try
            {
                _categoryRepository.Remove(existingCategoryToDelete);
                await _unitOfWork.CompleteAsync();

                return new CategoryResponse(existingCategoryToDelete);
            } 
            catch(Exception ex)
            {
                return new CategoryResponse($"An error occurred when saving the category: { ex.Message }");
            }
        }
    }
}