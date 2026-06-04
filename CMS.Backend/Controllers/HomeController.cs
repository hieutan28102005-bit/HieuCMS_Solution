using CMS.Backend.Models;
using CMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CMS.Backend.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Lấy số liệu thống kê từ database
            var postCount = await _context.Posts.CountAsync();
            var userCount = await _context.Users.CountAsync();
            var productCount = await _context.Products.CountAsync();
            var orderCount = await _context.Orders.CountAsync();

            // Lấy 5 bài viết mới nhất
            var recentPosts = await _context.Posts
                .OrderByDescending(p => p.Id)
                .Take(5)
                .Select(p => new { p.Title, p.Id, p.CreatedDate })
                .ToListAsync();

            ViewBag.PostCount = postCount;
            ViewBag.UserCount = userCount;
            ViewBag.ProductCount = productCount;
            ViewBag.OrderCount = orderCount;
            ViewBag.RecentPosts = recentPosts;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = System.Diagnostics.Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}