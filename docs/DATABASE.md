# DevTrack Pro — Database Documentation

## Database

**Name:** DevTrackProDB

**Database Engine:** Microsoft SQL Server

---

# Current Tables

## Roles

Purpose:

Stores the roles available within DevTrack Pro.

Current roles:

| RoleId | Name     |
| -----: | -------- |
|      1 | Admin    |
|      2 | Manager  |
|      3 | Employee |
|      4 | HR       |

---

## Users

Purpose:

Stores authentication/account information.

Conceptual fields:

* UserId
* Email
* PasswordHash
* RoleId
* IsActive

Relationship:

Users.RoleId → Roles.RoleId

---

## Departments

Purpose:

Stores company departments.

Current departments include:

* Engineering
* Human Resources
* Finance
* Marketing

---

## Employees

Purpose:

Stores employee profile and organizational information.

Conceptual fields:

* EmployeeId
* UserId
* FirstName
* LastName
* Phone
* DateOfJoining
* DepartmentId

Relationships:

Employees.UserId → Users.UserId

Employees.DepartmentId → Departments.DepartmentId

---

# Current Relationship Model

```text
Roles
  │
  └── 1 → many Users
                │
                └── 1 → 1 Employee
                              │
Departments ───── 1 → many ───┘
```

---

# Planned Tables

## Projects

Stores project information.

Potential fields:

* ProjectId
* Name
* Description
* StartDate
* EndDate
* Status

---

## ProjectMembers

Junction table for:

Employee ↔ Project

Purpose:

Allows multiple employees to belong to multiple projects.

---

## Tasks

Stores work items belonging to projects.

Potential fields:

* TaskId
* ProjectId
* Title
* Description
* AssignedTo
* Priority
* Status
* DueDate
* CreatedAt

---

## TaskComments

Stores comments associated with tasks.

Potential relationships:

Task → TaskComments

User → TaskComments

---

# Future Supporting Tables

Potential:

* RefreshTokens
* AuditLogs
* Notifications

These should only be introduced when required.

---

# Database Design Principles

* Use primary keys appropriately.
* Use foreign keys to maintain relationships.
* Respect referential integrity.
* Do not duplicate data unnecessarily.
* Use appropriate normalization.
* Add indexes when there is a justified query/performance need.
* Do not add database complexity without a real requirement.

---

# Important Learning Goal

The developer must understand the relationship between:

```text
Database
    ↕
EF Core
    ↕
C# Entities
    ↕
Services
    ↕
Controllers
    ↕
REST API
```

EF Core should not be treated as magic.
