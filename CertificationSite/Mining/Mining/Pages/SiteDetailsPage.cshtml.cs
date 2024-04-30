using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mining.Pages
{
    public class SiteDetailsPageModel : PageModel
    {
        private readonly MiningContext _context;

        public SiteDetailsPageModel(MiningContext context)
        {
            _context = context;
        }

        public Mining_Sites Site { get; set; }
        public List<Employees> Employees { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Site = await _context.Mining_Sites.FindAsync(id);

            if (Site == null)
            {
                return NotFound();
            }

            Employees = await _context.Employees
                .Where(e => e.SiteId == id)
                .ToListAsync();

            return Page();
        }
    }
}


