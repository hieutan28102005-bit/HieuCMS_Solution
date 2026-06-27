# HieuCMS Solution - Đồ Án Website Bán Hàng & Tin Tức (Gaming Gear)

Dự án đồ án môn học xây dựng một hệ thống CMS (Content Management System) và Website thương mại điện tử chuyên bán các sản phẩm Gaming Gear, kết hợp trang tin tức.

Hệ thống được chia thành 2 phần chính:
- **Backend (API & Admin Control Panel):** Xây dựng bằng `ASP.NET Core Web API` và `ASP.NET Core MVC`.
- **Frontend (Giao diện khách hàng):** Xây dựng bằng `ReactJS` và `Vite`.

## 🛠️ Công Nghệ Sử Dụng

### 1. Backend (`CMS.Backend` & `CMS.Data`)
- **Framework:** .NET 8 (ASP.NET Core MVC & Web API)
- **ORM:** Entity Framework Core (Code-First)
- **Cơ sở dữ liệu:** SQL Server
- **Tài liệu API:** Swagger / OpenAPI
- **Các tính năng nổi bật:**
  - RESTful APIs cho toàn bộ các thực thể (Sản phẩm, Đơn hàng, Bài viết,...).
  - Tích hợp bộ lọc (Filter) và phân trang (Pagination) tối ưu bằng LINQ.
  - Quản lý quyền truy cập (Authentication/Authorization) với các Role (Administrator, Editor).
  - Trang quản trị (Admin Panel) giao diện MVC tích hợp Bootstrap để thao tác trực tiếp (Thêm, Xóa, Sửa sản phẩm, đơn hàng, quảng cáo, v.v).

### 2. Frontend (`cms.frontend`)
- **Framework:** ReactJS (Vite)
- **Styling:** TailwindCSS
- **Các tính năng nổi bật:**
  - Giao diện thân thiện, hiện đại (Modern Web Design), đáp ứng mọi thiết bị (Responsive).
  - Tích hợp tính năng Giỏ hàng (Cart) và Thanh toán (Checkout).
  - Quản lý hồ sơ người dùng cá nhân (Cập nhật thông tin, Đổi mật khẩu, Lịch sử mua hàng).
  - Hệ thống Banner quảng cáo động được lấy trực tiếp từ Database.
  - Routing với `react-router-dom`.

---

##  Hướng Dẫn Cài Đặt Và Chạy Dự Án

### Yêu cầu hệ thống
- .NET 8 SDK
- SQL Server (hoặc SQL Server Express / LocalDB)
- Node.js (phiên bản >= 18)

### Bước 1: Khởi chạy Backend & Database
1. Mở Solution `HieuCMS_Solution.sln` bằng **Visual Studio**.
2. Kiểm tra chuỗi kết nối Database (`DefaultConnection`) trong file `CMS.Backend/appsettings.json` đảm bảo đúng với SQL Server của bạn.
3. Mở **Package Manager Console** (View > Other Windows > Package Manager Console), chọn Default project là `CMS.Data` và chạy lệnh cập nhật database:
   ```powershell
   Update-Database
