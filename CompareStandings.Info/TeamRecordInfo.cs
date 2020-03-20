namespace CompareStandings.Info
{
    public class TeamRecordInfo
    {
        private string _teamName;
        private int _homeWinCount;
        private int _homeLossCount;
        private int _awayWinCount;
        private int _awayLossCount;

        public TeamRecordInfo(string teamName, int homeWinCount, int homeLossCount, int awayWinCount, int awayLossCount)
        {
            _teamName = teamName;
            _homeWinCount = homeWinCount;
            _homeLossCount = homeLossCount;
            _awayWinCount = awayWinCount;
            _awayLossCount = awayLossCount;
        }

        public string TeamName => _teamName;

        public string OverallRecord
        {
            get
            {
                int wins = _homeWinCount + _awayWinCount;
                int losses = _homeLossCount + _awayLossCount;
                return $"{wins}-{losses}";
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
