using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Homework1.Core.Entity;

namespace Homework1.Core.Entity
{
    public class Product
    {
      
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode { get; set; }
        public int CategoryId { get; set; }

        // EntityFramework Category uzerinde tracking yapabilir.
        public virtual Category Category { get; set; }
       
        
        


   
    }
}