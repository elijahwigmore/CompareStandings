﻿namespace CompareStandings.Data
{
    public interface IStandingsData
    {
        public int GetRecord(int teamID);

        public int GetHomeRecord(int teamID);

        public int GetAwayRecord(int teamID);
    }
}