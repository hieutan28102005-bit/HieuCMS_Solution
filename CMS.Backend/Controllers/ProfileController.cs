using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CMS.Backend.Controllers
{
    // Profile: Tất cả user đã đăng nhập đều được truy cập
    [Authorize]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            // Lấy thông tin từ Claims
            var username = User.Identity?.Name;
            var fullName = User.FindFirst(ClaimTypes.GivenName)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            ViewBag.Username = username;
            ViewBag.FullName = fullName;
            ViewBag.Role = role;

            return View();
        }
    }
}