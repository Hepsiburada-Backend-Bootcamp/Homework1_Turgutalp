using System.Collections.Generic;

namespace Homework1.API.DTO
{
    public class CategoryWithProductDto: CategoryDto
    {
        public IEnumerable<ProductDto> Products { get; set; }
    }
}