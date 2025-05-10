# 🎓 Student Management Portal - ASP.NET Core MVC

Welcome to the **Student Management Portal**, a web-based CRUD application built using **ASP.NET Core MVC** and **Entity Framework Core**. Easily manage student records—add, view, update, and delete with a user-friendly UI and dynamic DataTable support!

---

## ✨ Features

✅ Add new students  
📋 View all students with search, sort, and pagination (via DataTables)  
✏️ Edit existing student details  
🗑️ Delete student records  
💽 SQL Server integration using EF Core

---

## 🛠️ Tech Stack

- ⚙️ ASP.NET Core MVC (.NET 6+)
- 🧩 Entity Framework Core
- 🗃️ SQL Server
- 🎨 Bootstrap 5
- 🔍 jQuery DataTables

---

## 📁 Project Structure

StudentPortal/
│
├── Controllers/
│ └── StudentController.cs
│
├── Models/
│ ├── Entities/
│ │ └── Student.cs
│ └── ViewModels/
│ ├── AddStudentViewModel.cs
│ └── UpdateStudentViewModel.cs
│
├── Views/
│ └── Student/
│ ├── Add.cshtml
│ ├── List.cshtml
│ ├── Edit.cshtml
│ └── Delete.cshtml
│
├── Data/
│ └── ApplicationDbContext.cs
│
├── wwwroot/
│ └── (static files: CSS, JS)
│
└── appsettings.json

yaml
Copy
Edit

---

## 🚀 Getting Started

### 🧰 Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download)
- SQL Server
- Visual Studio or VS Code

### ⚙️ Setup Instructions

1️⃣ Clone the repository:

```bash
git clone https://github.com/yourusername/StudentPortal.git
cd StudentPortal
2️⃣ Update the database connection string in appsettings.json:

json
Copy
Edit
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME;Database=StudentDb;Trusted_Connection=True;"
}
3️⃣ Apply database migrations:

bash
Copy
Edit
dotnet ef migrations add InitialCreate
dotnet ef database update
4️⃣ Run the application:

bash
Copy
Edit
dotnet run
Visit 👉 https://localhost:7293/Students/List in your browser.

📸 Screenshots
(Optional: Include UI screenshots like Add form, List with DataTable, Edit/Delete views)

🧠 Future Enhancements
🔐 Add user authentication & authorization

📤 Export to Excel/CSV

📡 AJAX-based updates and modals

📊 Dashboard and student stats

📄 License
MIT License - feel free to use and contribute! 🚀

🤝 Contributions
Pull requests are welcome! For major changes, please open an issue first to discuss what you would like to change.

🙌 Acknowledgements
Microsoft Docs

DataTables.net

Bootstrap
