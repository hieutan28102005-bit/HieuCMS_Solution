using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        // Bảng Categories
        public DbSet<Category> Categories { get; set; }

        // Bảng Posts
        public DbSet<Post> Posts { get; set; }

        // Bảng Users
        public DbSet<User> Users { get; set; }

        // Bảng CategoryProduct
        public DbSet<CategoryProduct> CategoriesProducts { get; set; }

        // Bảng Product
        public DbSet<Product> Products { get; set; }

        // Bảng Customer
        public DbSet<Customer> Customers { get; set; }

        // Bảng Order
        public DbSet<Order> Orders { get; set; }

        // Bảng OrderDetail
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}