using System.ComponentModel.DataAnnotations;

namespace Homework1.API.DTO
{
    public class CategoryDto
    {
        public int Id { get; set; }
        
        [Required]
        public string CategoryName { get; set; }
    }
}