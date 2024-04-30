using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;

namespace Mining.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public IndexModel(MiningContext context, ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Test");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var name = Request.Form["name"];
            var surname = Request.Form["surname"];
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            var role = Request.Form["userrole"];

            var user = new User
            {
                Name = name,
                Surname = surname,
                Email = email,
                Password = password,
                UserRole = role
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return RedirectToPage("LoginPage");
        }
    }
}