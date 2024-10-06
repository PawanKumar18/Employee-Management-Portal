using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagementApp.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "Department Name is required.")]
        [StringLength(50, ErrorMessage = "Department Name cannot be longer than 50 characters.")]
        [Display(Name = "Department")]
        public string DepartmentName { get; set; }

        // Navigation property
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
