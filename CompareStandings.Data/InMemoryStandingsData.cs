using CompareStandings.Core;
using System.Collections.Generic;

namespace CompareStandings.Data
{
    public class InMemoryStandingsData : IStandingsData
    {
        List<Team> teams;

        public InMemoryStandingsData()
        {
            teams = new List<Team>()
            {
                new Team() { ID = 1, Name = "Toronto Raptors" },
                new Team() { ID = 2, Name = "Milwaukee Bucks" },
                new Team() { ID = 3, Name = "Boston Celtics" },
                new Team() { ID = 4, Name = "Houston Rockets" },
                new Team() { ID = 5, Name = "Sacremento Kings" },
                new Team() { ID = 6, Name = "Los Angeles Lakers" }
            };
        }

        public int GetRecord(int teamID)
        {
            return 0;
        }

        public int GetHomeRecord(int teamID)
        {
            return 0;
        }

        public int GetAwayRecord(int teamID)
        {
            return 0;
        }

        public List<Team> GetAllTeams()
        {
            return teams;
        }
    }
}
