using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;

namespace Mining.Pages
{
    public class CertificationPageModel : PageModel
    {
        private readonly ILogger<CertificationPageModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public CertificationPageModel(MiningContext context, ILogger<CertificationPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public List<Certifications> certifications { get; set; }
        public List<Employees> employees { get; set; }

        public IActionResult OnGet ()
        {
            loadCertifications();
            loadEmployees();

            return Page();
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Certification being done");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var certName = Request.Form["certName"];
            var startdate = Request.Form["startDate"];
            var endDate = Request.Form["endDate"];
            var employeeId = int.Parse(Request.Form["employeeId"]);

            loadEmployees();

            var user = employees.FirstOrDefault(x => x.EmployeeId == employeeId);
            string fullName = user.Name + " "  + user.Surname;

            var cert = new Certifications
            {
                CertName = certName,
                StartDate = startdate,
                EndDate = endDate,
                CertOwner = fullName,
                EmployeeId = employeeId
            }; 

            _context.Certifications.Add(cert);
            _context.SaveChanges();

            loadCertifications();
            loadEmployees();

            return Page();
        }

        public void loadCertifications()
        {
            certifications = _context.Certifications.ToList();
        }

        public void loadEmployees()
        {
            employees = _context.Employees.ToList();
        }
    }
}
