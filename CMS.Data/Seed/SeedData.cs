using CMS.Data.Entities;

namespace CMS.Data.Seed
{
    public static class SeedData
    {
        public static void EnsureSeeded(ApplicationDbContext db)
        {
            db.Database.EnsureCreated();

            // =========================
            // Categories (Category)
            // =========================
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category { Name = "Lập trình", Description = "Danh mục lập trình" },
                    new Category { Name = "Thiết kế", Description = "Danh mục thiết kế" }
                );
                db.SaveChanges();
            }

            // =========================
            // CategoryProduct
            // =========================
            if (!db.CategoriesProducts.Any())
            {
                db.CategoriesProducts.AddRange(
                    new CategoryProduct { Name = "Laptop" },
                    new CategoryProduct { Name = "Khóa học" }
                );
                db.SaveChanges();
            }

            // =========================
            // Users
            // =========================
            if (!db.Users.Any())
            {
                db.Users.AddRange(
                    new User
                    {
                        Username = "admin",
                        PasswordHash = "123456",
                        FullName = "Nguyễn Tấn Hiệu",
                        Role = "Administrator" // map -> Admin
                    },
                    new User
                    {
                        Username = "editor01",
                        PasswordHash = "123456",
                        FullName = "Biên tập viên",
                        Role = "Editor" // map -> User
                    }
                );
                db.SaveChanges();
            }

            // =========================
            // Posts
            // =========================
            if (!db.Posts.Any())
            {
                var lapTrinh = db.Categories.FirstOrDefault(c => c.Name == "Lập trình");
                var categoryId = lapTrinh?.Id ?? db.Categories.First().Id;

                db.Posts.AddRange(
                    new Post
                    {
                        Title = "Học ASP.NET Core",
                        Content = "Nội dung ASP.NET Core",
                        ImageUrl = "image1.jpg",
                        CategoryId = categoryId
                    },
                    new Post
                    {
                        Title = "Học ReactJS",
                        Content = "Nội dung ReactJS",
                        ImageUrl = "image2.jpg",
                        CategoryId = categoryId
                    }
                );

                db.SaveChanges();
            }

            // =========================
            // Products
            // =========================
            if (!db.Products.Any())
            {
                var laptopCat = db.CategoriesProducts.FirstOrDefault(c => c.Name == "Laptop")
                                 ?? db.CategoriesProducts.First();

                var courseCat = db.CategoriesProducts.FirstOrDefault(c => c.Name == "Khóa học")
                                 ?? db.CategoriesProducts.First();

                db.Products.AddRange(
                    new Product
                    {
                        Name = "Laptop học lập trình",
                        Description = "Cấu hình vừa đủ cho học dev",
                        Price = 15000000m,
                        StockQuantity = 10,
                        ImageUrl = "laptop.jpg",
                        CategoryProductId = laptopCat.Id
                    },
                    new Product
                    {
                        Name = "Khóa học ASP.NET Core",
                        Description = "Nền tảng + bài tập",
                        Price = 2500000m,
                        StockQuantity = 50,
                        ImageUrl = "course.jpg",
                        CategoryProductId = courseCat.Id
                    }
                );

                db.SaveChanges();
            }

            // =========================
            // Customers
            // =========================
            if (!db.Customers.Any())
            {
                db.Customers.AddRange(
                    new Customer
                    {
                        FullName = "Nguyễn Văn A",
                        Email = "a@gmail.com",
                        Phone = "0900000001",
                        Address = "Hà Nội",
                        Password = "123456"
                    },
                    new Customer
                    {
                        FullName = "Trần Văn B",
                        Email = "b@gmail.com",
                        Phone = "0900000002",
                        Address = "HCM",
                        Password = "123456"
                    }
                );

                db.SaveChanges();
            }

            // =========================
            // Orders
            // =========================
            if (!db.Orders.Any())
            {
                var customer = db.Customers.FirstOrDefault(c => c.Email == "a@gmail.com")
                                ?? db.Customers.First();

                db.Orders.AddRange(
                    new Order
                    {
                        CustomerId = customer.Id,
                        Status = 0,
                        Notes = "Đơn hàng tạo mẫu"
                    }
                );

                db.SaveChanges();
            }

            // =========================
            // OrderDetails
            // =========================
            if (!db.OrderDetails.Any())
            {
                var order = db.Orders.FirstOrDefault();
                if (order != null)
                {
                    var p1 = db.Products.FirstOrDefault();
                    var p2 = db.Products.Skip(1).FirstOrDefault();

                    if (p1 != null)
                    {
                        db.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = order.Id,
                            ProductId = p1.Id,
                            Quantity = 1,
                            UnitPrice = p1.Price
                        });
                    }

                    if (p2 != null)
                    {
                        db.OrderDetails.Add(new OrderDetail
                        {
                            OrderId = order.Id,
                            ProductId = p2.Id,
                            Quantity = 2,
                            UnitPrice = p2.Price
                        });
                    }

                    db.SaveChanges();
                }
            }
        }
    }
}

