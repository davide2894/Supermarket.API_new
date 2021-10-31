using System.ComponentModel.DataAnnotations;

namespace Supermarket.API_new.Resources
{
    public class SaveCategoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
    }
}