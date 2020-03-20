using CompareStandings.Data;
using CompareStandings.Info;
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

        public IEnumerable<TeamRecordInfo> TeamRecordInfos;

        public IndexModel(IConfiguration config, IStandingsData standingsData, ILogger<IndexModel> logger)
        {
            _config = config;
            _standingsData = standingsData;
            _logger = logger;
        }

        public void OnGet()
        {
            TeamRecordInfos = _standingsData.GetAllTeamRecordInfos();
        }
    }
}
