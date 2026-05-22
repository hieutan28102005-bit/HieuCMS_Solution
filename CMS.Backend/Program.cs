using CMS.Data;
using CMS.Data.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Kết nối Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// ==================
// TẠO DỮ LIỆU MẪU
// ==================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    db.Database.EnsureCreated();

    // Category
    if (!db.Categories.Any())
    {
        db.Categories.AddRange(

            new Category
            {
                Name = "Lập trình",
                Description = "Danh mục lập trình"
            },

            new Category
            {
                Name = "Thiết kế",
                Description = "Danh mục thiết kế"
            }
        );

        db.SaveChanges();
    }

    // User
    if (!db.Users.Any())
    {
        db.Users.AddRange(

            new User
            {
                Username = "admin",
                PasswordHash = "123456",
                FullName = "Nguyễn Tấn Hiệu",
                Role = "Administrator"
            },

            new User
            {
                Username = "editor01",
                PasswordHash = "123456",
                FullName = "Biên tập viên",
                Role = "Editor"
            }
        );

        db.SaveChanges();
    }

    // Post
    if (!db.Posts.Any())
    {
        db.Posts.AddRange(

            new Post
            {
                Title = "Học ASP.NET Core",
                Content = "Nội dung ASP.NET Core",
                ImageUrl = "image1.jpg",
                CategoryId = 1
            },

            new Post
            {
                Title = "Học ReactJS",
                Content = "Nội dung ReactJS",
                ImageUrl = "image2.jpg",
                CategoryId = 1
            }
        );

        db.SaveChanges();
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();