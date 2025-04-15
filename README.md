# 🖥️ NQDTechPro - Laptop Store API

## 🔍 Giới thiệu

**NQDTechPro** là một RESTful Web API được xây dựng bằng **ASP.NET Core 8**, phục vụ cho hệ thống bán laptop online. API hỗ trợ quản lý sản phẩm, người dùng, đơn hàng và các chức năng thương mại điện tử cơ bản.

---

## 🧱 Công nghệ sử dụng

- ASP.NET Core 8
- Entity Framework Core
- Jwt Authentication
- SQL Server
- Swagger UI
- RESTful API principles

---

## 📁 Cấu trúc thư mục

```bash
NQDTechPro/
├── Controllers/             # Chứa các controller cho các endpoint
├── DTOs/                   # Data Transfer Objects
├── Data/                   # DbContext và cấu hình database
├── Interfaces/             # Interface cho service/repository
├── Mappers/                # AutoMapper profile
├── Models/                 # Entity models
├── Services/               # Xử lý logic nghiệp vụ
├── Properties/             # Thông tin cấu hình project
├── appsettings.json        # Cấu hình chung
├── appsettings.Development.json
├── Program.cs              # Khởi tạo và cấu hình app
├── NQDTechPro.csproj       # File cấu hình project
└── README.md

💡 Các tính năng chính (Use Cases)
🛒 Quản lý sản phẩm (Laptops)
Thêm/sửa/xoá laptop

Lấy danh sách laptop (lọc theo hãng, giá, cấu hình,...)

Tìm kiếm laptop theo từ khóa

👤 Quản lý người dùng
Đăng ký / đăng nhập

Phân quyền (Admin, Khách hàng)

📦 Đơn hàng
Tạo đơn hàng mới

Cập nhật trạng thái đơn hàng

Xem lịch sử mua hàng

🛍️ Giỏ hàng
Thêm/sửa/xoá sản phẩm trong giỏ hàng

Tính tổng giá tiền

🔒 Xác thực & Phân quyền
JWT Authentication

Role-based Authorization

📌 Ghi chú
Dự án này đang ở phiên bản đầu tiên (v1).

Chưa tích hợp thanh toán online, gửi email xác nhận.

Có thể mở rộng phần giao diện bằng Blazor hoặc ReactJS.

✨ Tác giả
Nguyễn Quang Duy
Email: [nguyenquangduy12112004@gmail.com]
GitHub: NguyenQuangDuy1211
Facebook: https://www.facebook.com/profile.php?id=100034063569091
SDT: 0346871187


