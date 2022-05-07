using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class ProductColorSize
    {
        public int Id { get; set; }
        public Nullable<int> ColorId { get; set; }
        public Color Color { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Product Product { get; set; }
        public Nullable<int> SizeiD { get; set; }
        public Size Size { get; set; }
    }
}
