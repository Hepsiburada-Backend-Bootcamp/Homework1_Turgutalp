using System.Collections.Generic;
using System.Collections.ObjectModel;
using Homework1.Core.Entity;

namespace Homework1.Core.Entity
{
    public class Category
    {
        public Category()
        {
            Products = new Collection<Product>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
        
        // Her kategorinin 1'den fazla product'i olabilir.
        public ICollection<Product> Products { get; set; }
    }
}