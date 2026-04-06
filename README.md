# Student Management System

## Backend: ASP.NET Core Web API

This project is a backend application built using ASP.NET Core Web API. It demonstrates basic CRUD operations, JWT authentication, and a clean layered architecture using Controller, Service, and Repository patterns.

### Project Features
- Create, read, update, and delete student records
- JWT-based authentication
- Layered architecture (Controller → Service → Repository)
- Entity Framework Core with SQL Server
- Swagger for API testing
- Global exception handling using middleware

### Technologies Used
- ASP.NET Core Web API (.NET 8)
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger

### Project Structure
```
StudentManagementSystem
├── API          (Controllers, Middleware)
├── Core         (Entities, DTOs, Interfaces, Services)
└── Infrastructure (Data, Repositories, Identity)
```

### How to Run the Backend

#### 1. Clone the repository
```bash
git clone https://github.com/your-username/student-management-system.git
cd student-management-system
```

#### 2. Update database connection
Open `appsettings.json` and update:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=StudentDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

#### 3. Run migrations
```bash
dotnet ef migrations add InitialCreate --project StudentManagementSystem.Infrastructure --startup-project StudentManagementSystem.API
dotnet ef database update --project StudentManagementSystem.Infrastructure --startup-project StudentManagementSystem.API
```

#### 4. Run the application
```bash
dotnet run --project StudentManagementSystem.API
```

#### 5. Open Swagger
```
https://localhost:xxxx/swagger
```

### Authentication
- Endpoint: `POST /api/auth/login`
- Provide email and password
- API returns a JWT token
- Use token in Swagger: `Bearer YOUR_TOKEN`
- Student APIs are protected using authorization

### API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| POST | /api/auth/login | Login and get JWT token |
| GET | /api/students | Get all students |
| GET | /api/students/{id} | Get student by ID |
| POST | /api/students | Add new student |
| PUT | /api/students/{id} | Update student |
| DELETE | /api/students/{id} | Delete student |

### Sample Request
```json
POST /api/students
{
  "name": "Venkat",
  "email": "venkat@gmail.com",
  "age": 24,
  "course": ".NET"
}
```

### Database
Student table fields: `Id`, `Name`, `Email`, `Age`, `Course`, `CreatedDate`

### Notes
- Entity Framework Core is used for database operations
- Global exception handling ensures consistent error responses
- Clean architecture is followed for maintainability

---

## Frontend: Angular UI

This is the frontend application built using Angular. It provides a user interface for managing students with JWT-based authentication.

### Frontend Features
- Login page with JWT authentication
- View all students in a searchable table
- Add new student with form validation
- Edit existing student details
- Delete student with confirmation
- Protected routes using Auth Guard
- JWT token automatically attached to all API calls via interceptor
- Responsive design with SCSS styling

### Frontend Technologies Used
- Angular 17+ (Standalone Components)
- TypeScript
- SCSS
- Angular Reactive Forms
- Angular HTTP Client
- JWT Interceptor
- Route Guards

### Frontend Project Structure
```
student-management-ui/
└── src/
    └── app/
        ├── auth/
        │   └── login/
        │       ├── login.component.ts
        │       ├── login.component.html
        │       └── login.component.scss
        ├── students/
        │   ├── student-list/
        │   │   ├── student-list.component.ts
        │   │   ├── student-list.component.html
        │   │   └── student-list.component.scss
        │   └── student-form/
        │       ├── student-form.component.ts
        │       ├── student-form.component.html
        │       └── student-form.component.scss
        ├── services/
        │   ├── auth.service.ts
        │   └── student.service.ts
        ├── guards/
        │   └── auth.guard.ts
        ├── interceptors/
        │   └── jwt.interceptor.ts
        ├── models/
        │   └── student.model.ts
        ├── app.routes.ts
        ├── app.config.ts
        └── environments/
            └── environment.ts
```

### How to Run the Frontend

#### 1. Navigate to frontend folder
```bash
cd student-management-ui
```

#### 2. Install dependencies
```bash
npm install
```

#### 3. Update API URL
Open `src/environments/environment.ts` and update the port to match your backend:
```typescript
export const environment = {
  production: false,
  apiUrl: 'https://localhost:7028'
};
```

#### 4. Run the application
```bash
ng serve
```

#### 5. Open browser
```
http://localhost:4200
```

### Frontend Login Credentials
- **Email:** admin@gmail.com
- **Password:** 1234

### Frontend Notes
- The app redirects to login page if no valid JWT token is found
- JWT token is stored in localStorage after successful login
- All API calls automatically include the Bearer token via JWT interceptor
- Auth Guard protects all student routes from unauthorized access
- Logout clears the token and redirects to login page

---

## Author
Venkata Ganesh Nanipalli