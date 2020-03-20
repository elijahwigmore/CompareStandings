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

        private readonly int _winCount;
        private readonly int _lossCount;

        private static int BestTeamDifferential;

        public TeamRecordInfo(string teamName, int homeWinCount, int homeLossCount, int awayWinCount, int awayLossCount)
        {
            _teamName = teamName;
            _homeWinCount = homeWinCount;
            _homeLossCount = homeLossCount;
            _awayWinCount = awayWinCount;
            _awayLossCount = awayLossCount;

            _winCount = _homeWinCount + _awayWinCount;
            _lossCount = _homeLossCount + _awayLossCount;
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
                    value = (double)_winCount / (double)(_winCount + _lossCount);
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
    }
}
