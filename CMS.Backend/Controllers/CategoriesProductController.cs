using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CMS.Backend.Controllers
{
    [Route("CategoryProduct")]
    [Authorize(Roles = "Administrator,Editor")]  // Cả Admin và Editor đều vào được
    public class CategoriesProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. TRANG DANH SÁCH
        [HttpGet("")]
        public IActionResult Index()
        {
            var data = _context.CategoriesProducts.OrderByDescending(c => c.Id).ToList();
            return View(data);
        }

        // 2. TRANG THÊM MỚI
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryProduct category)
        {
            if (ModelState.IsValid)
            {
                _context.CategoriesProducts.Add(category);
                _context.SaveChanges();
                TempData["Success"] = "Thêm danh mục sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // 3. TRANG SỬA
        [HttpGet("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            if (id <= 0) return BadRequest();

            var category = _context.CategoriesProducts.Find(id);
            if (category == null) return NotFound();

            return View(category);
        }

        [HttpPost("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CategoryProduct category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = _context.CategoriesProducts.Find(category.Id);
                if (existingCategory == null) return NotFound();

                existingCategory.Name = category.Name;

                _context.CategoriesProducts.Update(existingCategory);
                _context.SaveChanges();
                TempData["Success"] = "Cập nhật danh mục sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // 4. XỬ LÝ XÓA - CHỈ ADMIN MỚI ĐƯỢC PHÉP XÓA
        [HttpPost("Delete/{id}")]
        [Authorize(Roles = "Administrator")]  // 👈 SỬA THÀNH "Administrator"
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var category = _context.CategoriesProducts
                .Include(c => c.Products)
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
                return RedirectToAction(nameof(Index));

            // Kiểm tra có sản phẩm liên quan không
            if (category.Products != null && category.Products.Any())
            {
                TempData["Error"] = $"Không thể xóa danh mục '{category.Name}' vì đang có sản phẩm liên quan.";
                return RedirectToAction(nameof(Index));
            }

            _context.CategoriesProducts.Remove(category);
            _context.SaveChanges();
            TempData["Success"] = "Xóa danh mục sản phẩm thành công!";

            return RedirectToAction(nameof(Index));
        }
    }
}