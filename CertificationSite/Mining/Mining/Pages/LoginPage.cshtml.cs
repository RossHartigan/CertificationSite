using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;

namespace Mining.Pages
{
    public class LoginPageModel : PageModel
    {

        private readonly ILogger<IndexModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public LoginPageModel(MiningContext context, ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation("Login");

            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            var email = Request.Form["email"];
            var password = Request.Form["password"];

            List<User> users = _context.Users.ToList();

            foreach (var x in users)
            {
                if (x.Email == email && x.Password == password)
                {
                    _logger.LogInformation("Successfully Logged in!");
                    return RedirectToPage("/HomePage");
                }
                else if (x.Email == email && x.Password != password)
                {
                    _logger.LogInformation("Incorrect Password!");

                }
                else
                {
                    _logger.LogInformation("Incorrect Username & Password!");
                }
            }

            return Page(); 
        }
    }
}
