# DevTrack Pro — Project Memory

## 1. Project Identity

**Project Name:** DevTrack Pro

**Purpose:**

DevTrack Pro is a production-style Employee, Organization, Project, and Task Management REST API.

It is also a complete practical learning project for mastering the .NET backend development lifecycle.

The project should teach the developer how to move from:

Requirement → Business Rules → Database → Backend → API → Authentication → Authorization → Testing → Docker → CI/CD → Cloud Deployment.

The goal is not simply to produce working code. The developer must understand why each technology, architectural decision, and implementation exists.

---

## 2. Core Technology Stack

* C#
* .NET 9
* ASP.NET Core Web API
* Entity Framework Core
* Microsoft SQL Server
* REST API
* JWT Authentication
* Git
* GitHub
* Docker
* CI/CD
* Azure / Cloud Deployment

### Version Note

The existing learning project uses .NET 9.

.NET 9 is a Standard Term Support release. For future production deployment, .NET 10 LTS may be considered if appropriate.

Do not migrate versions unnecessarily during learning.

---

## 3. Main Business Purpose

DevTrack Pro represents an internal management system for a small company.

It allows authorized users to:

* Manage users
* Manage roles
* Manage departments
* Manage employees
* Create projects
* Assign employees to projects
* Create tasks
* Assign tasks
* Track task progress
* Add task comments
* Search and filter information
* View dashboard statistics

---

## 4. Roles

Initial roles:

* Admin
* Manager
* Employee
* HR

Permissions must be implemented through authentication and authorization.

Role-based authorization should not be assumed to cover every business rule. Some rules may depend on ownership, project membership, task assignment, or resource state.

---

## 5. Core Entities

Current entities:

* Roles
* Users
* Departments
* Employees

Planned entities:

* Projects
* ProjectMembers
* Tasks
* TaskComments

Possible future supporting entities:

* RefreshTokens
* AuditLogs
* Notifications

Only add supporting entities when there is a genuine requirement.

---

## 6. Important Domain Distinction

### User

Authentication/account information.

Typical information:

* UserId
* Email
* PasswordHash
* RoleId
* IsActive

### Employee

Employee/profile/organizational information.

Typical information:

* EmployeeId
* UserId
* FirstName
* LastName
* Phone
* DateOfJoining
* DepartmentId

Do not merge User and Employee without a strong architectural reason.

---

## 7. Current Relationships

Role → Users

One role can belong to many users.

User → Employee

One user account is associated with one employee profile.

Department → Employees

One department can contain many employees.

Future:

Project ↔ Employee

Many-to-many relationship implemented through ProjectMembers.

Project → Tasks

One project can contain many tasks.

Task → TaskComments

One task can contain many comments.

---

## 8. Project Workflow

Managers/admins can create projects.

Employees can be assigned to projects.

Projects contain tasks.

Tasks can be assigned to employees.

Task workflow:

Todo → In Progress → Review → Completed

Potential additional states:

* Blocked
* Cancelled

Status transitions should eventually follow business rules rather than allowing arbitrary changes.

---

## 9. Authentication Flow

Registration:

Register → Validate → Hash Password → Store User

Login:

Login → Find User → Verify Password → Generate JWT → Return Token

Authenticated request:

Client → JWT → Authentication → Claims → Authorization → Controller

Passwords must never be stored as plain text.

---

## 10. Architecture Philosophy

Architecture should be introduced gradually.

Do not create every layer at the beginning.

The eventual architecture may contain:

API

* Controllers
* Middleware
* Program.cs

Application

* Services
* DTOs
* Interfaces

Domain

* Entities
* Enums

Infrastructure

* DbContext
* Data
* Persistence

Tests

* Unit
* Integration

Every layer must have a clear reason for existing.

Avoid architecture for appearance alone.

---

## 11. Learning Philosophy

The developer wants to become an AI-native developer rather than an AI-dependent developer.

AI should act as:

* Teacher
* Mentor
* Coding guide
* Reviewer
* Debugging partner
* Architecture reviewer
* Interview coach

The developer must understand the code rather than blindly copying it.

Preferred learning cycle:

Explain → Design → Implement → Test → Review → Continue

Always explain WHY as well as HOW.

---

## 12. Important Development Rule

Do not dump the complete project implementation at once.

Build milestone-by-milestone.

Before every major milestone explain:

1. What it is
2. Why it exists
3. What problem it solves
4. Where it fits into DevTrack Pro
5. What files will change
6. What concepts will be learned
7. What the expected result is

Then implement the milestone.

---

## 13. Anti-Overengineering Rule

Do not add technologies simply because they are popular.

Do not introduce the following unless a real requirement justifies them:

* Microservices
* Kubernetes
* Kafka
* Redis
* CQRS
* Event sourcing
* Message brokers
* GraphQL
* Other unnecessary distributed-system technologies

Prioritize depth and understanding over technology count.

---

## 14. Security Principles

Security is part of the entire project.

Important areas:

* Password hashing
* JWT security
* Authorization
* Input validation
* HTTPS
* Environment variables
* Secret management
* SQL injection protection
* EF Core parameterization
* CORS
* Least privilege
* Secure configuration
* Proper error handling

---

## 15. Final Learning Outcome

By the end, the developer should be able to receive a new requirement and reason through:

Requirement
→ Business Rules
→ Database Design
→ Entities
→ EF Core
→ Services
→ DTOs
→ Controllers
→ Authentication
→ Authorization
→ Validation
→ Testing
→ Git
→ Docker
→ CI/CD
→ Deployment

The real goal is not merely completing DevTrack Pro.

The goal is learning how to build professional .NET backend systems.
