using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [StringLength(255)]
        public string SubTitle { get; set; }
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
