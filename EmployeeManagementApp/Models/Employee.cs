using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeeManagementApp.Models
{
    [Table("Employee")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Department is required.")]
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int DepartmentID { get; set; }

        // Navigation properties
        [ValidateNever]
        public virtual Department Department { get; set; }
        
        [ValidateNever]
        public virtual ICollection<SalaryHistory> SalaryHistories { get; set; }
    }
}
