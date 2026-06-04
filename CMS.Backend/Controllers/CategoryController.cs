using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CMS.Backend.Controllers
{
    [Authorize(Roles = "Administrator,Editor")]  // Cả Admin và Editor
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category/Index
        public IActionResult Index()
        {
            var list = _context.Categories
                .Include(c => c.Posts)
                .OrderByDescending(c => c.Id)
                .ToList();

            return View(list);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return View(category);
            }

            if (!ModelState.IsValid)
            {
                return View(category);
            }

            _context.Categories.Add(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return RedirectToAction(nameof(Index));
            }

            var oldCategory = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (oldCategory == null)
            {
                return RedirectToAction(nameof(Index));
            }

            oldCategory.Name = category.Name;
            oldCategory.Description = category.Description;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _context.Categories
                .Include(c => c.Posts)
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = _context.Categories
                .Include(c => c.Posts)
                .FirstOrDefault(x => x.Id == id);

            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }

            // Bắt lỗi: xóa cha phải check có con không
            if (category.Posts != null && category.Posts.Any())
            {
                TempData["Error"] = $"Không thể xóa danh mục '{category.Name}' vì đang có bài viết liên quan.";
                return RedirectToAction(nameof(Index));
            }

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
