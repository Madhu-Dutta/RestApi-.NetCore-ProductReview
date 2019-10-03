using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Test { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public  virtual ICollection<CategoryProduct> ProductCategory { get; set; }// = new List<CategoryProduct>();
    }
}
