using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementApp.Models
{
    [Table("SalaryHistory")]
    public class SalaryHistory
    {
        [Key]
        public int SalaryHistoryID { get; set; }

        [Required(ErrorMessage = "Employee is required.")]
        [ForeignKey("Employee")]
        [Display(Name = "Employee")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "Salary is required.")]
        [DataType(DataType.Currency)]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be a positive value.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "Effective Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Effective Date")]
        public DateTime EffectiveDate { get; set; }

        // Navigation property
        public virtual Employee Employee { get; set; }
    }
}
