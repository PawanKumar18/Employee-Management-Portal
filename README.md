# Employee Management Application

The **Employee Management Application** is a web-based system built using **ASP.NET Core MVC** and **Entity Framework Core**. It enables users to manage employee records, departments, and salary histories, featuring user authentication and authorization through **ASP.NET Core Identity**.

---

## 📂 **Key Functionalities**

- **User Registration & Login**
- **Employee CRUD Operations**
- **Department Management**
- **Salary History Tracking**

---

## 🗃 **Database Design**

### **Database Contexts**

- **_ApplicationDbContext:_**  
  Handles ASP.NET Core Identity operations such as user data storage.

- **_EmployeeDBContext:_**  
  Manages application-specific data like employees, departments, and salary histories.

---

### **Database Tables**

#### Identity Tables:
- **_AspNetUsers:_**  
  Stores user account details.
  
- **_AspNetRoles, AspNetUserRoles, etc.:_**  
  Other Identity-related tables for roles, claims, and user-role associations.

#### Application Tables:
| Table Name      | Description                         |
|-----------------|-------------------------------------|
| **Department**  | Stores department information.      |
| **Employee**    | Stores employee details, references departments via a foreign key. |
| **SalaryHistory** | Tracks salary records associated with employees. |

---

## 🔗 **Database Schema**

### **Department**
| Column Name    | Data Type        | Key          |
|----------------|------------------|--------------|
| `DepartmentID` | int              | Primary Key  |
| `DepartmentName` | string         |              |

### **Employee**
| Column Name    | Data Type        | Key          |
|----------------|------------------|--------------|
| `EmployeeID`   | int              | Primary Key  |
| `FirstName`    | string           |              |
| `LastName`     | string           |              |
| `DepartmentID` | int              | Foreign Key (FK) |

### **SalaryHistory**
| Column Name    | Data Type        | Key          |
|----------------|------------------|--------------|
| `SalaryHistoryID` | int           | Primary Key  |
| `EmployeeID`   | int              | Foreign Key (FK) |
| `Salary`       | decimal          |              |
| `EffectiveDate`| DateTime         |              |

---

**Database Schema Diagram**

![Database Schema](https://github.com/user-attachments/assets/bee236e4-64a9-443c-9fb6-5db6d35c96c5)
