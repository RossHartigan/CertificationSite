using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mining.Data;
using Mining.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Mining.Pages
{
    public class SitesPageModel : PageModel
    {
        private readonly ILogger<SitesPageModel> _logger;
        private readonly MiningContext _context;
        private readonly IConfiguration _configuration;

        public SitesPageModel(MiningContext context, ILogger<SitesPageModel> logger, IConfiguration configuration)
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
        }

        public List<Mining_Sites> MiningSites { get; set; }

        public void OnGet()
        {
            MiningSites = _context.Mining_Sites.ToList();
        }

    }
}

