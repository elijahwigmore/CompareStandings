using CompareStandings.Core;
using System.Collections.Generic;

namespace CompareStandings.Data
{
    public interface IStandingsData
    {
        public string GetRecord(int teamID);

        public string GetHomeRecord(int teamID);

        public string GetAwayRecord(int teamID);

        public List<Team> GetAllTeams();
    }
}
