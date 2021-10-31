using Supermarket.API_new.Domain.Models;

namespace Supermarket.API_new.Domain.Services.Communication
{
    public class SaveCategoryResponse : BaseResponse
    {
        public Category ResponseCategory { get; private set; }

        private SaveCategoryResponse(bool success, string message, Category category) : base(success, message)
        {
            ResponseCategory = category;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="category">Saved category.</param>
        /// <returns>Response.</returns>
        public SaveCategoryResponse(Category category) : this(true, string.Empty, category)
        { }

        /// <summary>
        /// Creates an error response.
        /// </summary>
        /// <param name="message">Error Message</param>
        /// <returns>Error Message</returns>
        public SaveCategoryResponse(string message) : this(false, message, null)
        { }
    }
}