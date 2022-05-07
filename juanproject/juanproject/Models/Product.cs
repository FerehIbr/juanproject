using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double Count { get; set; }
        public string Description { get; set; }
        public bool Availability { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<ProductColorSize> productColorSizes { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> SizeIds { get; set; } = new List<int>();
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
