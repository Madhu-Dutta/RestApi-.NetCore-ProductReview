﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Model
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
//        public virtual ICollection<CategoryProduct> ProductDatas{ get; set; }
        public  virtual ICollection<CategoryProduct> ProductCategory { get; set; }// = new List<CategoryProduct>();
    }
}
