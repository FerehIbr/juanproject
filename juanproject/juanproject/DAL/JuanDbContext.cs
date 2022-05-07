using juanproject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.DAL
{
    public class JuanDbContext : IdentityDbContext
    {
        public JuanDbContext(DbContextOptions<JuanDbContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HomeSlider> HomeSliders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColorSize> productColorSizes { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
