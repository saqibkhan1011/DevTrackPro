# DevTrack Pro — Architecture

## Current Architecture

The project is being built incrementally.

Do not assume the final architecture already exists.

Introduce architectural components when the project reaches the appropriate milestone.

---

# Target Architecture

```text
Client
   │
   ↓
ASP.NET Core API
   │
   ├── Middleware
   │
   ├── Authentication
   │
   ├── Authorization
   │
   ↓
Controllers
   │
   ↓
Application Services
   │
   ↓
Domain
   │
   ↓
Infrastructure
   │
   ↓
EF Core
   │
   ↓
SQL Server
```

---

# Target Project Structure

```text
DevTrackPro/
│
├── docs/
│   ├── PROJECT_MEMORY.md
│   ├── CURRENT_STATE.md
│   ├── DATABASE.md
│   ├── ARCHITECTURE.md
│   └── API_DESIGN.md
│
├── src/
│   ├── DevTrackPro.API/
│   ├── DevTrackPro.Application/
│   ├── DevTrackPro.Domain/
│   └── DevTrackPro.Infrastructure/
│
├── tests/
│
├── Dockerfile
├── README.md
└── .gitignore
```

This is the eventual target, not the structure that must be created immediately.

---

# Architectural Principles

## Separation of Concerns

Different components should have different responsibilities.

Controllers should handle HTTP concerns.

Services should contain appropriate business logic.

Infrastructure should handle persistence-related concerns.

Domain should represent core business concepts.

---

# Controllers

Controllers expose HTTP endpoints.

Example:

```text
GET /api/employees
POST /api/employees
GET /api/employees/{id}
PUT /api/employees/{id}
DELETE /api/employees/{id}
```

Controllers should not become giant classes containing all business logic.

---

# Services

Services contain application/business operations.

Example:

```text
EmployeeService
ProjectService
TaskService
AuthService
```

Introduce these when the application becomes complex enough to benefit from them.

---

# DTOs

DTOs represent data entering or leaving the API.

Examples:

* CreateEmployeeRequest
* UpdateEmployeeRequest
* EmployeeResponse
* LoginRequest
* LoginResponse
* CreateProjectRequest
* CreateTaskRequest

Entities should not automatically be exposed directly through the API.

---

# Middleware

Middleware participates in the ASP.NET Core request pipeline.

Potential middleware:

* Global exception handling
* Logging
* Authentication-related pipeline components

Introduce middleware when the relevant requirement appears.

---

# Authentication

JWT authentication will eventually protect API endpoints.

Flow:

```text
Client
 ↓
Login
 ↓
JWT
 ↓
Authenticated Request
 ↓
Authentication
 ↓
Authorization
 ↓
Controller
```

---

# Authorization

Authorization determines what an authenticated user is allowed to do.

Possible mechanisms:

* Roles
* Claims
* Business rules
* Ownership
* Project membership
* Task assignment

---

# Architecture Rule

Never introduce a pattern simply because it looks professional.

Every abstraction must solve an actual problem.
