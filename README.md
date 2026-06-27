# HieuCMS Solution - Hệ Thống Website Bán Hàng & Tin Tức Gaming Gear

![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![React](https://img.shields.io/badge/React-18-20232A?style=for-the-badge&logo=react&logoColor=61DAFB)
![TailwindCSS](https://img.shields.io/badge/Tailwind_CSS-38B2AC?style=for-the-badge&logo=tailwind-css&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white)

**HieuCMS** là một dự án đồ án môn học hoàn chỉnh, kết hợp giữa hệ thống quản trị nội dung (CMS) và Website Thương mại điện tử chuyên cung cấp các thiết bị, linh kiện máy tính (Gaming Gear). Dự án cung cấp luồng quy trình khép kín từ việc quản lý hàng hóa, tin tức ở Backend cho đến trải nghiệm mua sắm mượt mà ở Frontend.

---

## Chức Năng Nổi Bật

### 1. Dành cho Khách Hàng (Frontend - ReactJS)
- **Trang chủ & Giao diện:** Giao diện được thiết kế hiện đại (Glassmorphism, Dark/Light accents), tối ưu hóa trải nghiệm người dùng (UX/UI) và tương thích mọi kích thước màn hình (Responsive Design).
- **Trải nghiệm mua sắm:** 
  - Khám phá sản phẩm theo danh mục.
  - Tìm kiếm sản phẩm, lọc theo giá và sắp xếp linh hoạt.
  - Quản lý giỏ hàng (Cart) với tính năng cập nhật số lượng trực tiếp.
  - Chức năng Checkout (Thanh toán) lưu trữ thông tin đơn hàng chi tiết.
- **Quản lý Tài Khoản:** 
  - Đăng ký, Đăng nhập (Authentication).
  - Quản lý thông tin cá nhân (Cập nhật địa chỉ, Số điện thoại).
  - Lịch sử mua hàng (Xem chi tiết từng đơn hàng, tổng tiền, trạng thái đơn hàng).
- **Tin tức & Blog:** Đọc các bài viết công nghệ, thủ thuật setup góc máy được cập nhật mới nhất từ CMS.

### 2. Dành cho Quản Trị Viên (Backend - Admin Control Panel)
- **Quản trị Sản Phẩm & Danh mục:** Thêm, Sửa, Xóa (CRUD) sản phẩm, quản lý số lượng tồn kho, giá bán và hình ảnh.
- **Quản lý Đơn Hàng:** Xem chi tiết các đơn hàng khách đã đặt, thay đổi trạng thái đơn hàng (Chờ duyệt -> Đang giao -> Hoàn thành) và thống kê doanh thu.
- **Quản lý Nội Dung (CMS):** Cập nhật bài viết, blog công nghệ, hướng dẫn người dùng.
- **Hệ thống Banner Động:** Tùy biến quảng cáo, slide trang chủ trực tiếp từ trang quản trị.
- **Phân Quyền Hệ Thống:** Tích hợp Identity (Administrator, Editor) giúp bảo mật trang quản trị.

---

## 🛠️ Công Nghệ Tiêu Biểu Được Sử Dụng

| Thành phần | Công nghệ / Thư viện | Vai trò |
| :--- | :--- | :--- |
| **Backend API** | ASP.NET Core 8 Web API | Xử lý logic, cung cấp RESTful API cho Frontend. |
| **Backend MVC** | ASP.NET Core MVC & Bootstrap | Giao diện quản trị (Admin Dashboard) Server-side rendering. |
| **Database** | SQL Server & Entity Framework Core | Lưu trữ dữ liệu, truy vấn qua LINQ, quản lý Code-First Migrations. |
| **Frontend** | React 18, Vite | Xây dựng giao diện Single Page Application (SPA). |
| **Styling** | Tailwind CSS | Utility-first CSS giúp thiết kế giao diện linh hoạt, hiện đại. |
| **API Docs** | Swagger / OpenAPI | Tự động sinh tài liệu API giúp Frontend dễ dàng tích hợp. |

---

##  Hướng Dẫn Cài Đặt Và Chạy Dự Án (Local Development)

Để chạy dự án trên máy cá nhân, vui lòng làm theo các bước chi tiết sau:

### Yêu cầu hệ thống cần có:
- **[Visual Studio 2022](https://visualstudio.microsoft.com/)** (Hỗ trợ .NET 8)
- **[SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)** (Developer hoặc Express Edition)
- **[Node.js](https://nodejs.org/)** (Phiên bản 18.x trở lên)

### Bước 1: Thiết lập & Khởi chạy Backend (Cơ sở dữ liệu & API)
1. Clone dự án về máy và mở file Solution `HieuCMS_Solution.sln` bằng **Visual Studio**.
2. Thiết lập chuỗi kết nối Database:
   - Mở file `appsettings.json` trong project `CMS.Backend`.
   - Tìm mục `"ConnectionStrings": { "DefaultConnection": "..." }` và chỉnh sửa lại tên `Server` cho khớp với SQL Server instance của bạn (ví dụ: `Server=.\\SQLEXPRESS;...`).
3. Khởi tạo Cơ sở dữ liệu:
   - Trên menu Visual Studio, chọn **Tools** > **NuGet Package Manager** > **Package Manager Console**.
   - Tại ô **Default project** trong console, chọn `CMS.Data`.
   - Gõ lệnh sau và nhấn Enter:
     ```powershell
     Update-Database
     ```
4. Chạy Backend:
   - Đặt `CMS.Backend` làm Startup Project (Chuột phải vào `CMS.Backend` > Set as Startup Project).
   - Nhấn **F5** hoặc bấm nút **Run** (màu xanh lá) để khởi động server.
   - Trình duyệt sẽ tự động mở trang Swagger: `https://localhost:7135/swagger` (Liệt kê toàn bộ API).
   - Truy cập trang Quản trị Admin tại: `https://localhost:7135/`

### Bước 2: Thiết lập & Khởi chạy Frontend (ReactJS)
1. Mở một cửa sổ Terminal mới (hoặc Command Prompt / PowerShell).
2. Di chuyển vào thư mục Frontend:
   ```bash
   cd cms.frontend
