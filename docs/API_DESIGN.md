# DevTrack Pro — API Design

## API Style

DevTrack Pro uses a REST-style HTTP API.

Resources should be represented using clear URLs and appropriate HTTP methods.

---

# Authentication

```text
POST /api/auth/register
POST /api/auth/login
```

---

# Employees

```text
GET    /api/employees
GET    /api/employees/{id}
POST   /api/employees
PUT    /api/employees/{id}
DELETE /api/employees/{id}
```

Potential query parameters:

```text
GET /api/employees?search=saqib
GET /api/employees?departmentId=1
```

---

# Departments

```text
GET    /api/departments
GET    /api/departments/{id}
POST   /api/departments
PUT    /api/departments/{id}
DELETE /api/departments/{id}
```

---

# Projects

Planned:

```text
GET    /api/projects
GET    /api/projects/{id}
POST   /api/projects
PUT    /api/projects/{id}
DELETE /api/projects/{id}
```

Project membership endpoints will be designed when that phase begins.

---

# Tasks

Planned:

```text
GET    /api/tasks
GET    /api/tasks/{id}
POST   /api/tasks
PUT    /api/tasks/{id}
DELETE /api/tasks/{id}
```

Task filtering may include:

```text
/api/tasks?status=InProgress
/api/tasks?assignedTo=5
```

---

# Roles

Planned:

```text
GET /api/roles
GET /api/roles/{id}
```

Additional management operations will depend on authorization requirements.

---

# HTTP Status Codes

Expected usage:

```text
200 OK
201 Created
204 No Content
400 Bad Request
401 Unauthorized
403 Forbidden
404 Not Found
409 Conflict
500 Internal Server Error
```

---

# API Design Principles

* Use meaningful resource names.
* Use HTTP methods appropriately.
* Use route parameters for resource identity.
* Use query parameters for filtering/searching.
* Validate request bodies.
* Return meaningful status codes.
* Use DTOs where appropriate.
* Do not expose sensitive information.
* Protect endpoints with authentication/authorization where required.

---

# Important

The API design is a living document.

Update it when major endpoint or business-rule decisions are made.

Do not treat the example endpoints above as immutable if implementation requirements later justify a change.
