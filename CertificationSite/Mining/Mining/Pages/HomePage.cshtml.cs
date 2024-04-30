using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mining.Pages
{
    public class HomePageModel : PageModel
    {
        private readonly ILogger<HomePageModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public HomePageModel(MiningContext context, ILogger<HomePageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task LoadMiningSites()
        {
            MiningSites = await _context.Mining_Sites.ToListAsync();
        }

        public IActionResult OnGet()
        {
            LoadMiningSites().Wait();
            return Page();
        }

        public List<Mining_Sites> MiningSites { get; set; }
    }
}




