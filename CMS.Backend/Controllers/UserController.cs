using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class UserController : Controller
    {
        static List<User> users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Username = "admin_thai",
                FullName = "Nguyễn Cao Thái",
                Role = "Administrator"
            },

            new User()
            {
                Id = 2,
                Username = "editor_01",
                FullName = "Trần Văn Biên Tập",
                Role = "Editor"
            },

            new User()
            {
                Id = 3,
                Username = "author_minh",
                FullName = "Lê Quang Minh",
                Role = "Author"
            }
        };

        // Hiển thị danh sách
        public IActionResult Index()
        {
            return View(users);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            user.Id = users.Max(x => x.Id) + 1;

            users.Add(user);

            return RedirectToAction("Index");
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            return View(user);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(User user)
        {
            var oldUser = users.FirstOrDefault(x => x.Id == user.Id);

            if (oldUser != null)
            {
                oldUser.Username = user.Username;
                oldUser.FullName = user.FullName;
                oldUser.Role = user.Role;
            }

            return RedirectToAction("Index");
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(x => x.Id == id);

            if (user != null)
            {
                users.Remove(user);
            }

            return RedirectToAction("Index");
        }
    }
}