using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mining.Data;
using Mining.Models;

namespace Mining.Pages
{
    public class UpdateCertificationPageModel : PageModel
    {
        private readonly ILogger<UpdateCertificationPageModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public UpdateCertificationPageModel(MiningContext context, ILogger<UpdateCertificationPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public Certifications Certification_Details { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Certification_Details = await _context.Certifications.FindAsync(id);

            if (Certification_Details == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(string action)
        {
            if (action == "update")
            {
                var newStartDate = Request.Form["newStartDate"];
                var newEndDate = Request.Form["newEndDate"];
                int certId = int.Parse(Request.Form["certId"]);

                
                var certification = _context.Certifications.Find(certId);

                if (certification == null)
                {
                    return NotFound();
                }
                
                certification.StartDate = newStartDate;
                certification.EndDate = newEndDate;

                _context.SaveChanges();

                return RedirectToPage("/CertificationPage");
            }
            else if (action == "delete")
            {
                
                int certId = int.Parse(Request.Form["certId"]);

                var certification = _context.Certifications.Find(certId);

                if (certification == null)
                {
                    return NotFound();
                }

                _context.Certifications.Remove(certification);
                _context.SaveChanges();
               
                return RedirectToPage("/CertificationPage");
            }
            else
            {
                return BadRequest("Invalid action");
            }
        }

    }
}
