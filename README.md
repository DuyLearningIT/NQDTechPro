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
