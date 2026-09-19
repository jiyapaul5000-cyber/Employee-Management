# Employee Management System

A full-stack Employee Management System built with **ASP.NET Core Web API** and **JavaScript**. The application provides JWT authentication and complete employee management with CRUD operations, search, filtering, sorting, pagination, and validation.

## 🚀 Features

- JWT Authentication & Authorization
- Employee CRUD operations
- Search employees by name
- Filter employees by minimum salary
- Salary sorting
- Pagination
- Input validation
- API error handling
- Swagger/OpenAPI documentation
- SQLite database with Entity Framework Core
- CORS-enabled frontend integration

## 🛠️ Tech Stack

**Backend:** C#, ASP.NET Core Web API, Entity Framework Core, SQLite, JWT, Swagger/OpenAPI

**Frontend:** HTML, CSS, JavaScript, Fetch API, Local Storage

**Tools:** Visual Studio Code, .NET SDK, Git, GitHub

## 🏗️ Architecture

```text
Frontend
   ↓
Controller
   ↓
Service
   ↓
Entity Framework Core
   ↓
SQLite Database
```

## 📡 API Endpoints

### 🔐 Authentication

| Method | Endpoint | Description |
|:---:|---|---|
| `POST` | `/api/Auth/login` | Authenticate user and generate JWT token |

### 👥 Employee Management

| Method | Endpoint | Description |
|:---:|---|---|
| `GET` | `/api/Employees` | Get all employees |
| `GET` | `/api/Employees/{id}` | Get employee by ID |
| `POST` | `/api/Employees` | Create a new employee |
| `PUT` | `/api/Employees/{id}` | Update an existing employee |
| `DELETE` | `/api/Employees/{id}` | Delete an employee |

### 🔎 Query Parameters

The `GET /api/Employees` endpoint supports:

| Parameter | Description |
|---|---|
| `search` | Search employees by name |
| `minSalary` | Filter employees by minimum salary |
| `descending` | Sort salary in descending order |
| `page` | Specify page number |
| `pageSize` | Specify number of employees per page |

### Example

```text
GET /api/Employees?search=Jiya&minSalary=30000&descending=true&page=1&pageSize=10
```

## 📸 Screenshots

### Login

![Login](Screenshots/login.png)

### Employee Dashboard

![Dashboard](Screenshots/dashboard.png)

### Search & Filtering

![Search and Filtering](Screenshots/search-filter.png)

### Add Employee

![Add Employee](Screenshots/add-employee.png)

### Update Employee

![Update Employee](Screenshots/update-employee.png)

### Delete Employee

![Delete Employee](Screenshots/delete-employee.png)

## 🔐 Authentication

The application uses **JWT-based authentication**.

After successful login:

1. The backend generates a JWT token.
2. The frontend stores the token in Local Storage.
3. The token is sent with protected API requests.
4. ASP.NET Core validates the token before allowing access to protected endpoints.

```text
Login
  ↓
JWT Token
  ↓
Local Storage
  ↓
Authorization: Bearer <token>
  ↓
Authentication
  ↓
Authorization
  ↓
Employee API
```

## 🗄️ Database

The application uses **SQLite** with **Entity Framework Core** for database operations and migrations.

```text
Employee Model
      ↓
AppDbContext
      ↓
Entity Framework Core
      ↓
SQLite Database
```

## 📁 Project Structure

```text
EmployeeAPI
├── Controllers
│   ├── EmployeesController.cs
│   └── AuthController.cs
├── Data
│   └── AppDbContext.cs
├── DTOs
│   ├── CreateEmployeeDto.cs
│   ├── EmployeeDto.cs
│   ├── UpdateEmployeeDto.cs
│   └── LoginDto.cs
├── Migrations
├── Models
│   └── Employee.cs
├── Services
│   └── EmployeeService.cs
├── Program.cs
├── appsettings.json
└── .gitignore
```

## ⚙️ How to Run

### Backend

```bash
dotnet restore
dotnet run
```

### Frontend

Open the `EmployeeFrontend` folder and run `index.html` using **Live Server**.

## 🧪 Testing

The application was tested for:

- Valid and invalid login
- JWT authentication
- Expired and invalid JWT tokens
- Employee creation
- Employee update
- Employee deletion
- Input validation
- Search and filtering
- Pagination
- CORS requests
- API error handling

## 👩‍💻 Author

**Jiya Paul**

B.Tech Computer Science & Engineering

