using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;
using Microsoft.EntityFrameworkCore;

namespace Mining.Pages
{
    public class EmployeeDetailsPageModel : PageModel
    {
        private readonly MiningContext _context;

        public EmployeeDetailsPageModel(MiningContext context)
        {
            _context = context;
        }

        public Employees Employee_Details { get; set; }
        public List<Certifications> certifications { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Employee_Details = await _context.Employees.FindAsync(id);

            if (Employee_Details == null)
            {
                return NotFound();
            }

            certifications = await _context.Certifications
                .Where(c => c.EmployeeId == id)
                .ToListAsync();

            if (certifications == null)
            {
                return NotFound();
            }

            return Page();
        }

    }
}
