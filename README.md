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


**Steps for Setting Up and Running the Application**

Update Connection Strings:
Ensure your appsettings.json file has the correct connection strings as shown above. Update the server name if you're using a different SQL Server instance.

Create the Databases:

Open SQL Server Management Studio (SSMS).
Connect to your SQL Server instance.
Run the above SQL script to create the databases.
Import Schema and Data :

Select the EmployeeDB database in SSMS.
Open a new query window and execute your schema script db_schema.sql to create tables and constraints.
Import data_dump, open it and execute it to insert data into the tables.
Build and Run the Application:

In Visual Studio, right-click on the solution and select Restore NuGet Packages.
Build the solution (Build > Build Solution) or press Ctrl+Shift+B.
Run the application (F5 to run with debugging or Ctrl+F5 to run without debugging). The app should launch in your default browser at a URL like (https://localhost:7155/).
Test the Application:

Register a new user and log in.
Access features like Add Employee, View Departments, and View Salary History.
Apply Entity Framework Migrations (for Identity Database):

If you're not using SQL scripts for the Identity database:

powershell
Copy code
Update-Database -Context ApplicationDbContext


**Web Application Sceenshots**

Login
![image](https://github.com/user-attachments/assets/caec4e7b-9682-4762-b22f-6bdc5ba83766)

Register
![image](https://github.com/user-attachments/assets/ae9cb661-0e55-42c4-8ca0-78bbcbacb14f)

Home page
![image](https://github.com/user-attachments/assets/a2e90474-017c-42b2-bf04-f105d411392d)

Add Employee
![image](https://github.com/user-attachments/assets/785252c2-e1be-4992-8eb7-9d056fb9bb30)

Edit Employee
![image](https://github.com/user-attachments/assets/c081687c-e3ae-4c17-abc4-ad06a314527d)

Salary History
![image](https://github.com/user-attachments/assets/02ffc657-7c2c-4527-916a-7e2614b48099)



