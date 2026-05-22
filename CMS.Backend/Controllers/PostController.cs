using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Backend.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách
        public IActionResult Index()
        {
            var posts = _context.Posts.ToList();

            return View(posts);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(Post post)
        {
            post.CreatedDate = DateTime.Now;

            _context.Posts.Add(post);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var post = _context.Posts
                .FirstOrDefault(x => x.Id == id);

            return View(post);
        }

        // POST: Edit
        [HttpPost]
        public IActionResult Edit(Post post)
        {
            var oldPost = _context.Posts
                .FirstOrDefault(x => x.Id == post.Id);

            if (oldPost != null)
            {
                oldPost.Title = post.Title;
                oldPost.Content = post.Content;
                oldPost.ImageUrl = post.ImageUrl;

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // Delete
        public IActionResult Delete(int id)
        {
            var post = _context.Posts
                .FirstOrDefault(x => x.Id == id);

            if (post != null)
            {
                _context.Posts.Remove(post);

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}