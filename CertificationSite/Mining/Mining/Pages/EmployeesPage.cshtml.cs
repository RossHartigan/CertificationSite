using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;
using Mining.Pages;
using System.Data;
using System.ComponentModel.DataAnnotations;

namespace Mining.Pages
{
    public class EmployeesPageModel : PageModel
    {
        private readonly ILogger<EmployeesPageModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public EmployeesPageModel(MiningContext context, ILogger<EmployeesPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Employee Added");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var name = Request.Form["name"];
            var surname = Request.Form["surname"];
            var siteid = int.Parse(Request.Form["siteid"]);

            var employee = new Employees
            {
                Name = name,
                Surname = surname,
                SiteId = siteid
            };

            loadEmployees();

            _context.Employees.Add(employee);
            _context.SaveChanges();

            return RedirectToPage("/EmployeesPage");
        }

        public List<Employees> EmployeesList { get; set; }

        public void OnGet()
        {
            loadEmployees();
        }

        public void loadEmployees()
        {
            EmployeesList = _context.Employees.ToList();
            RedirectToPage("/EmployeesPage");
        }
    }
}

