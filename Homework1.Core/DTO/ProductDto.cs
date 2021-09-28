using System.ComponentModel.DataAnnotations;

namespace Homework1.API.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} alani gereklidir.")]
        public string ProductName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "{0} alani 1'den buyuk bir deger olmalidir")]
        public int ProductStock { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "{0} alani 1'den buyuk bir deger olmalidir")]
        public decimal ProductPrice { get; set; }

        public int CategoryId { get; set; }
    }
}