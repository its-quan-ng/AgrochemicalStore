# 🌾 Hệ Thống Quản Lý Cửa Hàng Nông Dược | Agricultural Store Management System

[![.NET Framework](https://img.shields.io/badge/.NET%20Framework-2.0-blue.svg)](https://dotnet.microsoft.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE)

Phần mềm quản lý cửa hàng nông dược toàn diện, hỗ trợ quản lý kho, bán hàng, công nợ và báo cáo.

*A comprehensive agricultural supply store management system with inventory, sales, debt tracking, and reporting features.*

---

## 📋 Giới Thiệu | Overview

**Tiếng Việt:**

Hệ thống quản lý cửa hàng nông dược là ứng dụng Windows Forms được phát triển để giúp các cửa hàng kinh doanh thuốc trừ sâu, phân bón và vật tư nông nghiệp quản lý hoạt động kinh doanh hiệu quả. Phần mềm hỗ trợ quản lý đầy đủ từ nhập hàng, bán lẻ, bán sỉ, theo dõi công nợ đến báo cáo doanh thu và tồn kho.

**English:**

An agricultural store management system built with Windows Forms to help pesticide, fertilizer, and farming supply retailers manage their business operations efficiently. The software provides complete support from inventory management, retail/wholesale sales, debt tracking to revenue and stock reports.

---

## 🚀 Công Nghệ | Technology Stack

- **Framework:** .NET Framework 2.0
- **UI:** Windows Forms
- **Database:** Microsoft Access (.mdb) / SQL Server (migrate-ready)
- **Reporting:** Microsoft ReportViewer
- **Architecture:** 3-Layer (Business Object, Data Layer, Controller)

---

## ✨ Tính Năng | Features

### 📦 Quản Lý | Management
- ✅ **Sản phẩm** - Quản lý thông tin thuốc, phân bón, vật tư nông nghiệp
- ✅ **Khách hàng** - Quản lý khách lẻ và đại lý
- ✅ **Nhà cung cấp** - Quản lý thông tin nhà cung cấp
- ✅ **Đơn vị tính** - Quản lý các đơn vị tính (kg, lít, chai, gói...)

*Product management, customer (retail & wholesale), supplier management, unit of measure*

### 💼 Nghiệp Vụ | Operations
- 📥 **Nhập hàng** - Lập phiếu nhập, quản lý mã sản phẩm, hạn sử dụng
- 🛒 **Bán hàng** - Bán lẻ và bán sỉ (đại lý)
- 💰 **Thanh toán** - Quản lý thanh toán công nợ khách hàng
- 💸 **Phiếu chi** - Quản lý các khoản chi phí
- 📊 **Công nợ** - Tổng hợp và theo dõi công nợ khách hàng

*Purchase orders, retail & wholesale sales, payment collection, expense tracking, debt management*

### 📈 Báo Cáo | Reports
- 📋 **Số lượng tồn** - Báo cáo tồn kho theo sản phẩm
- 📉 **Số lượng bán** - Thống kê sản phẩm bán chạy
- 📅 **Sản phẩm hết hạn** - Cảnh báo sản phẩm gần/đã hết hạn sử dụng
- 💵 **Doanh thu** - Báo cáo doanh thu theo thời gian
- 🧾 **In phiếu** - In phiếu nhập, phiếu bán, phiếu chi, phiếu thanh toán

*Stock reports, best-selling products, expiry alerts, revenue reports, printable receipts*

---

## 🗄️ Database Migration: Access → SQL Server

Project ban đầu sử dụng **Microsoft Access** (.mdb). Để migrate sang **SQL Server**:

*Originally uses Microsoft Access (.mdb). To migrate to SQL Server:*

### Bước 1: Import Data | Step 1: Import Data

Sử dụng **SQL Server Management Studio (SSMS)**:

1. Chuột phải vào database đích → **Tasks** → **Import Data...**
2. **Source**: Microsoft Access → chọn file `cuahang.mdb`
3. **Destination**: SQL Server → chọn database
4. **Copy data and schema** → Next → Finish
5. Kiểm tra và điều chỉnh:
   - Primary Keys / Foreign Keys
   - Data types (`Yes/No` → `bit`, `Currency` → `money`)
   - Identity columns

📹 **Video hướng dẫn:** *(Đính kèm link video của bạn)*

### Bước 2: Update Connection String | Step 2: Update Connection

Sửa file `DataService.cs`:

```csharp
// Old Access connection
using System.Data.OleDb;
public static String m_ConnectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=cuahang.dll;";

// New SQL Server connection
using System.Data.SqlClient;
public static String m_ConnectString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;";
```

Thay thế tất cả `OleDb*` → `Sql*` (OleDbConnection → SqlConnection, OleDbCommand → SqlCommand...)

---

## 📦 Cài Đặt | Installation

### Yêu Cầu | Requirements
- Windows XP/7/8/10/11
- .NET Framework 2.0 hoặc cao hơn
- Microsoft Access Database Engine (nếu dùng .mdb)
- SQL Server Express/Standard (nếu migrate)

### Cài Đặt | Setup

1. Clone repository:
```bash
git clone https://github.com/yourusername/cuahang-nongduoc.git
cd cuahang-nongduoc
```

2. Mở solution trong Visual Studio:
```bash
CuahangNongDuoc.sln
```

3. Cấu hình connection string trong `DataService.cs`

4. Build và chạy (F5)

---

## 🏗️ Cấu Trúc Project | Project Structure

```
CuahangNongduoc/
├── BusinessObject/       # Các lớp đối tượng nghiệp vụ
├── Controller/           # Các controller xử lý logic
├── DataLayer/            # Tầng truy cập dữ liệu (Factory pattern)
├── Report/               # Các template báo cáo (.rdlc)
├── Resources/            # Icons, hình ảnh
├── frm*.cs               # Các form giao diện
└── DataService.cs        # Lớp quản lý kết nối database
```

---

## 📸 Screenshots

*(Thêm ảnh chụp màn hình các form chính)*

---

## 🤝 Đóng Góp | Contributing

Mọi đóng góp đều được chào đón! Vui lòng:

1. Fork repository
2. Tạo branch mới (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Tạo Pull Request

*Contributions are welcome! Please fork the repo and submit a pull request.*

---

## 📝 License

Distributed under the MIT License. See `LICENSE` for more information.

---

## 📧 Liên Hệ | Contact

Project Link: [https://github.com/yourusername/cuahang-nongduoc](https://github.com/yourusername/cuahang-nongduoc)

---

## 🙏 Acknowledgments

- Microsoft ReportViewer
- XPExplorerBar library
- .NET Community

---

**Made with ❤️ for Vietnamese farmers and agricultural retailers**


