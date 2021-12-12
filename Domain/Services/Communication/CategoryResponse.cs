using Supermarket.API_new.Domain.Models;

namespace Supermarket.API_new.Domain.Services.Communication
{
    public class CategoryResponse : BaseResponse
    {
        public Category ResponseCategory { get; private set; }

        private CategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            ResponseCategory = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public CategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <returns>Error Message</returns>
        public CategoryResponse(string message) : this(false, message, null)
        { }
    }
}