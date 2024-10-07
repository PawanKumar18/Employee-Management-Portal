using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YourNamespace.Models;

namespace EmployeeManagementApp.Controllers
{
    public class SalaryHistoriesController : Controller
    {
        private readonly EmployeeDBContext _context;

        public SalaryHistoriesController(EmployeeDBContext context)
        {
            _context = context;
        }

        // GET: SalaryHistories
        public async Task<IActionResult> Index(int? departmentId)
        {
            // Retrieve all departments to populate the dropdown
            var departments = await _context.Departments.ToListAsync();
            ViewBag.Departments = new SelectList(departments, "DepartmentID", "DepartmentName");

            if (departmentId == null)
            {
                // If no department is selected, display the selection form
                return View();
            }

            // Validate if the selected department exists
            var selectedDepartment = await _context.Departments
                .FirstOrDefaultAsync(d => d.DepartmentID == departmentId);

            if (selectedDepartment == null)
            {
                return NotFound();
            }

            // Retrieve salary histories for employees in the selected department
            var salaryHistories = await _context.SalaryHistories
                .Include(sh => sh.Employee)
                    .ThenInclude(e => e.Department)
                .Where(sh => sh.Employee.DepartmentID == departmentId)
                .OrderBy(sh => sh.Employee.LastName)
                .ThenBy(sh => sh.EffectiveDate)
                .ToListAsync();

            ViewBag.SelectedDepartment = selectedDepartment.DepartmentName;

            return View(salaryHistories);
        }
    }
}
