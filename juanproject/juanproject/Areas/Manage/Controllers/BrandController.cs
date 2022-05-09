using juanproject.DAL;
using juanproject.Extensions;
using juanproject.Helpers;
using juanproject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace juanproject.Areas.Manage.Controllers
{
    [Area("manage")]

    public class BrandController : Controller
    {
        private readonly JuanDbContext _context;
        private readonly IWebHostEnvironment _env;

        public BrandController(JuanDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index(bool? status, int page = 1)
        {
            ViewBag.Status = status;

            IEnumerable<Brand> brands = await _context.Brands

                .Where(t => status != null ? t.IsDeleted == status : true)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            ViewBag.PageIndex = page;
            ViewBag.PageCount = Math.Ceiling((double)brands.Count() / 5);

            return View(brands.Skip((page - 1) * 5).Take(5));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (brand.ImageFile != null)
            {
                if (!brand.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("ImageFile", "Secilen Seklin Novu Uygun Deyil");
                    return View();
                }
                if (!brand.ImageFile.CheckFileSize(30))
                {
                    ModelState.AddModelError("ImageFile", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View();
                }
                brand.Image = brand.ImageFile.CreateFile(_env, "assets", "img", "brand");
            }
            brand.CreatedAt = DateTime.UtcNow.AddHours(4);

            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Update(int? id, bool? status, int page = 1)
        {
            if (id == null) return BadRequest();

            Brand brand = await _context.Brands.FirstOrDefaultAsync(t => t.Id == id);

            if (brand == null) return NotFound();

            return View(brand);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand, bool? status, int page = 1)
        {
            if (!ModelState.IsValid) return View(brand);

            if (id == null) return BadRequest();

            if (id != brand.Id) return BadRequest();

            Brand dbBrand = await _context.Brands.FirstOrDefaultAsync(t => t.Id == id);
            brand.Image = dbBrand.Image;

            if (dbBrand == null) return NotFound();


            if (brand.ImageFile != null)
            {
                if (!brand.ImageFile.CheckFileContentType("image/png"))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Novu Uygun Deyil");
                    return View(dbBrand);
                }
                if (!brand.ImageFile.CheckFileSize(30))
                {
                    ModelState.AddModelError("LogoImage", "Secilen Seklin Olcusu Maksimum 30 Kb Ola Biler");
                    return View(dbBrand);
                }
                Helper.DeleteFile(_env, dbBrand.Image, "assets", "img", "brand");
                dbBrand.Image = brand.ImageFile.CreateFile(_env, "assets", "img", "brand");
            }


            dbBrand.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", new { status = status, page = page });
        }
   
    }
}
