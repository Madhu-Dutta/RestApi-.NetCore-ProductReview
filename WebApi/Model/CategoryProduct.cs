using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class CategoryProduct
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }

        //RelationShip
        //[ForeignKey("ProductId")]
        public Product Product { get; set; }
        //[ForeignKey("CategoryId")]
        public Category Category { get; set; }


    }
}
