using CMS.Data;
using CMS.Data.Entities;
using Microsoft.AspNetCore.Authentication.Cookies; // 👈 THÊM THƯ VIỆN NÀY
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Kết nối Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

// ==========================================
// 1. ĐĂNG KÝ DỊCH VỤ COOKIE AUTHENTICATION (THÊM ĐOẠN NÀY)
// ==========================================
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";               // Nếu chưa đăng nhập, tự động đá về đây
        options.AccessDeniedPath = "/Account/AccessDenied"; // Nếu sai quyền (Vd: Editor vào vùng Admin) thì đá về đây
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);   // Cookie hết hạn sau 30 phút
    });

builder.Services.AddControllersWithViews();

// Configure Authorize (thêm Policy tùy chọn - hiện dùng Roles trực tiếp)
builder.Services.AddAuthorization();

var app = builder.Build();

// ==================
// TẠO DỮ LIỆU MẪU (SEED DATA) - dùng 1 file SeedData
// ==================
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    CMS.Data.Seed.SeedData.EnsureSeeded(db);
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

// ==========================================
// 2. KÍCH HOẠT MIDDLEWARE PHÂN QUYỀN (SỬA LẠI ĐÚNG THỨ TỰ)
// ==========================================
app.UseAuthentication(); // 👈 PHẢI ĐỨNG TRƯỚC (Xác minh xem ông là ai?)
app.UseAuthorization();  // 👈 PHẢI ĐỨNG SAU (Kiểm tra xem ông có quyền vào không?)

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();