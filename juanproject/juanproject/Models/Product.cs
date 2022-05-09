using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class Product : BaseEntity
    {

        [StringLength(255)]
        public string Name { get; set; }
        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double ExTax { get; set; }
        public int Count { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [StringLength(1000)]
        public string MainImage { get; set; }
        public bool IsAvailable { get; set; }
        public Nullable<int> CategoryId { get; set; }
        public Category Category { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
      
        public List<ProductColorSize> ProductColorSizes { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
       
      
        [NotMapped]
        public List<int> Counts { get; set; } = new List<int>();
        [NotMapped]
        public IFormFile MainImageFile { get; set; }
        [NotMapped]
        public IFormFile[] ProductImagesFile { get; set; }

        [NotMapped]
        public List<int> TagIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> ColorIds { get; set; } = new List<int>();
        [NotMapped]
        public List<int> SizeIds { get; set; } = new List<int>();
    }
}
