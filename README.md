### Project Overview

The Employee Management Application is a web-based system developed using ASP.NET Core MVC and Entity Framework Core. It allows users to manage employee records, departments, and salary histories. The application includes functionality for user authentication and authorization using ASP.NET Core Identity with Individual User Accounts.

### Database Design
#### Database Contexts
**_ApplicationDbContext:_** Used by ASP.NET Core Identity to store user data.

**_EmployeeDBContext:_** Used for application-specific data like employees, departments, and salary histories.

#### Tables
**_AspNetUsers:_** Stores user accounts (managed by Identity).

**_AspNetRoles, AspNetUserRoles, etc.:_** Other Identity tables for roles and claims.

**_Department:_** Stores department information.

**_Employee:_** Stores employee details and references departments.

**_SalaryHistory:_** Stores salary records associated with employees.


### Database Schema Diagram

#### Department
| Column Name     | Key         |
|-----------------|-------------|
| DepartmentID    | Primary Key (PK) |
| DepartmentName  |             |

#### Employee
| Column Name     | Key         |
|-----------------|-------------|
| EmployeeID      | Primary Key (PK) |
| FirstName       |             |
| LastName        |             |
| DepartmentID    | Foreign Key (FK) |

#### SalaryHistory
| Column Name     | Key         |
|-----------------|-------------|
| SalaryHistoryID | Primary Key (PK) |
| EmployeeID      | Foreign Key (FK) |
| Salary          |             |
| EffectiveDate   |             |
