﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class ProductColorSize
    {
        public Nullable<int> Id { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Color Color { get; set; }
        public int Count { get; set; }
        public Nullable<int> SizeId { get; set; }
        public Size Size { get; set; }
    }
}
