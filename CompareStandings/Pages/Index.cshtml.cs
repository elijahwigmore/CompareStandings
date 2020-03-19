using CompareStandings.Core;
using CompareStandings.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CompareStandings.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        private readonly IStandingsData _standingsData;
        private readonly ILogger<IndexModel> _logger;

        public IEnumerable<Team> Teams;

        public IndexModel(IConfiguration config, IStandingsData standingsData, ILogger<IndexModel> logger)
        {
            _config = config;
            _standingsData = standingsData;
            _logger = logger;
        }

        public void OnGet()
        {
            Teams = _standingsData.GetAllTeams();
        }
    }
}
