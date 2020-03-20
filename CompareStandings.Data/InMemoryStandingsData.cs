using CompareStandings.Core;
using CompareStandings.Info;
using System.Collections.Generic;
using System.Linq;

namespace CompareStandings.Data
{
    public class InMemoryStandingsData : IStandingsData
    {
        List<Team> teams;
        List<Game> games;
        List<TeamRecordInfo> teamRecordInfos;

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

            games = new List<Game>()
            {
                new Game() { ID = 1, HomeTeamID = 6, AwayTeamID = 1, HomeTeamPoints = 111, AwayTeamPoints = 99 },
                new Game() { ID = 2, HomeTeamID = 2, AwayTeamID = 1, HomeTeamPoints = 110, AwayTeamPoints = 98 },
                new Game() { ID = 3, HomeTeamID = 4, AwayTeamID = 2, HomeTeamPoints = 80, AwayTeamPoints = 113 },
                new Game() { ID = 4, HomeTeamID = 6, AwayTeamID = 1, HomeTeamPoints = 86, AwayTeamPoints = 95 },
                new Game() { ID = 5, HomeTeamID = 5, AwayTeamID = 6, HomeTeamPoints = 106, AwayTeamPoints = 90 },
                new Game() { ID = 6, HomeTeamID = 6, AwayTeamID = 4, HomeTeamPoints = 118, AwayTeamPoints = 108 },
                new Game() { ID = 7, HomeTeamID = 3, AwayTeamID = 6, HomeTeamPoints = 82, AwayTeamPoints = 98 },
                new Game() { ID = 8, HomeTeamID = 5, AwayTeamID = 6, HomeTeamPoints = 90, AwayTeamPoints = 111 },
                new Game() { ID = 9, HomeTeamID = 3, AwayTeamID = 4, HomeTeamPoints = 91, AwayTeamPoints = 99 },
                new Game() { ID = 10, HomeTeamID = 1, AwayTeamID = 2, HomeTeamPoints = 94, AwayTeamPoints = 86 },
                new Game() { ID = 11, HomeTeamID = 5, AwayTeamID = 1, HomeTeamPoints = 91, AwayTeamPoints = 114 },
                new Game() { ID = 12, HomeTeamID = 1, AwayTeamID = 5, HomeTeamPoints = 94, AwayTeamPoints = 115 },
                new Game() { ID = 13, HomeTeamID = 4, AwayTeamID = 6, HomeTeamPoints = 106, AwayTeamPoints = 96 },
                new Game() { ID = 14, HomeTeamID = 3, AwayTeamID = 1, HomeTeamPoints = 104, AwayTeamPoints = 96 },
                new Game() { ID = 15, HomeTeamID = 2, AwayTeamID = 3, HomeTeamPoints = 101, AwayTeamPoints = 97 },
                new Game() { ID = 16, HomeTeamID = 2, AwayTeamID = 1, HomeTeamPoints = 82, AwayTeamPoints = 85 },
                new Game() { ID = 17, HomeTeamID = 2, AwayTeamID = 3, HomeTeamPoints = 81, AwayTeamPoints = 94 },
                new Game() { ID = 18, HomeTeamID = 4, AwayTeamID = 1, HomeTeamPoints = 110, AwayTeamPoints = 97 },
                new Game() { ID = 19, HomeTeamID = 6, AwayTeamID = 5, HomeTeamPoints = 103, AwayTeamPoints = 87 },
                new Game() { ID = 20, HomeTeamID = 4, AwayTeamID = 2, HomeTeamPoints = 112, AwayTeamPoints = 114 },
                new Game() { ID = 21, HomeTeamID = 4, AwayTeamID = 5, HomeTeamPoints = 119, AwayTeamPoints = 96 },
                new Game() { ID = 22, HomeTeamID = 1, AwayTeamID = 2, HomeTeamPoints = 105, AwayTeamPoints = 117 },
                new Game() { ID = 23, HomeTeamID = 5, AwayTeamID = 6, HomeTeamPoints = 89, AwayTeamPoints = 102 },
                new Game() { ID = 24, HomeTeamID = 1, AwayTeamID = 5, HomeTeamPoints = 94, AwayTeamPoints = 90 },
                new Game() { ID = 25, HomeTeamID = 2, AwayTeamID = 5, HomeTeamPoints = 80, AwayTeamPoints = 107 },
                new Game() { ID = 26, HomeTeamID = 2, AwayTeamID = 1, HomeTeamPoints = 89, AwayTeamPoints = 110 },
                new Game() { ID = 27, HomeTeamID = 2, AwayTeamID = 5, HomeTeamPoints = 113, AwayTeamPoints = 91 },
                new Game() { ID = 28, HomeTeamID = 5, AwayTeamID = 4, HomeTeamPoints = 105, AwayTeamPoints = 94 },
                new Game() { ID = 29, HomeTeamID = 3, AwayTeamID = 6, HomeTeamPoints = 116, AwayTeamPoints = 86 },
                new Game() { ID = 30, HomeTeamID = 1, AwayTeamID = 4, HomeTeamPoints = 87, AwayTeamPoints = 115 }
            };

            teamRecordInfos = Enumerable.Range(1, teams.Count).Select(id => new TeamRecordInfo(
                GetTeamName(id),
                GetHomeWinCount(id),
                GetHomeLossCount(id),
                GetAwayWinCount(id),
                GetAwayLossCount(id)
            )).OrderByDescending(r => r.WinPercentage).ToList();
        }

        public List<TeamRecordInfo> GetAllTeamRecordInfos()
        {
            return teamRecordInfos;
        }

        private string GetTeamName(int teamID)
        {
            return teams.Where(r => r.ID == teamID).Select(r => r.Name).FirstOrDefault();
        }

        private int GetHomeWinCount(int teamID)
        {
            return games.Where(r => r.HomeTeamID == teamID && r.HomeTeamPoints > r.AwayTeamPoints).Count();
        }

        private int GetHomeLossCount(int teamID)
        {
            return games.Where(r => r.HomeTeamID == teamID && r.HomeTeamPoints < r.AwayTeamPoints).Count();
        }        

        private int GetAwayWinCount(int teamID)
        {
            return games.Where(r => r.AwayTeamID == teamID && r.AwayTeamPoints > r.HomeTeamPoints).Count();
        }

        private int GetAwayLossCount(int teamID)
        {
            return games.Where(r => r.AwayTeamID == teamID && r.AwayTeamPoints < r.HomeTeamPoints).Count();
        }
    }
}
