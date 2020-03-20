using CompareStandings.Info;
using System.Collections.Generic;

namespace CompareStandings.Data
{
    public interface IStandingsData
    {
        public List<TeamRecordInfo> GetAllTeamRecordInfos();
    }
}
