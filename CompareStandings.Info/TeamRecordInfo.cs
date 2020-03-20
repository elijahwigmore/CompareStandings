using System.Collections.Generic;
using System.Linq;

namespace CompareStandings.Info
{
    public class TeamRecordInfo
    {
        private string _teamName;
        private int _homeWinCount;
        private int _homeLossCount;
        private int _awayWinCount;
        private int _awayLossCount;
        private int _totalPointsFor;
        private int _totalPointsAgainst;

        private readonly int _winCount;
        private readonly int _lossCount;
        private readonly int _gameCount;

        private static int BestTeamDifferential;

        public TeamRecordInfo(string teamName, int homeWinCount, int homeLossCount, int awayWinCount, int awayLossCount, int totalPointsFor, int totalPointsAgainst)
        {
            _teamName = teamName;
            _homeWinCount = homeWinCount;
            _homeLossCount = homeLossCount;
            _awayWinCount = awayWinCount;
            _awayLossCount = awayLossCount;
            _totalPointsFor = totalPointsFor;
            _totalPointsAgainst = totalPointsAgainst;

            _winCount = _homeWinCount + _awayWinCount;
            _lossCount = _homeLossCount + _awayLossCount;
            _gameCount = _winCount + _lossCount;
        }

        public static void SetBestTeamDifferential(IEnumerable<TeamRecordInfo> teamRecordInfos)
        {
            BestTeamDifferential = teamRecordInfos.Select(r => r.GetTeamDifferential()).Max();
        }

        private int GetTeamDifferential()
        {
            return _winCount - _lossCount;
        }

        public string TeamName => _teamName;

        public int WinCount => _winCount;

        public int LossCount => _lossCount;

        public string WinPercentage
        {
            get
            {
                double value;
                if (_winCount == 0)
                {
                    value = 0.0;
                }
                else
                {
                    value = _winCount / (double)_gameCount;
                }

                return $"{value:.000}";
            }
        }

        public double GamesBehind
        {
            get
            {
                return (BestTeamDifferential - GetTeamDifferential()) / 2.0;
            }
        }

        public string HomeRecord
        {
            get
            {
                return $"{_homeWinCount}-{_homeLossCount}";
            }
        }

        public string AwayRecord
        {
            get
            {
                return $"{_awayWinCount}-{_awayLossCount}";
            }
        }

        public string PointsForPerGame
        {
            get
            {
                double value = _totalPointsFor / (double)_gameCount;
                return $"{value:0.0}";
            }
        }

        public string PointsAgainstPerGame
        {
            get
            {
                double value = _totalPointsAgainst / (double)_gameCount;
                return $"{value:0.0}";
            }
        }

        // TODO: Figure out how to do formatting in JS so the point variables can be doubles and differential can subtract the two
        public string PointDifferentialPerGame
        {
            get
            {
                double value = (_totalPointsFor - _totalPointsAgainst) / (double)_gameCount;
                return $"{value:0.0}";
            }
        }
    }
}
