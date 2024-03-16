
using Microsoft.EntityFrameworkCore;

namespace Mission10API.Data
{
    public class EFBowlingRepository : IBowlingRepository
    {
        private BowlerContext _bowlerContext;
        public EFBowlingRepository(BowlerContext temp) {
            _bowlerContext = temp;
        }
        public IEnumerable<Bowler> Bowlers => _bowlerContext.Bowlers;

        public IEnumerable<Team> Teams => _bowlerContext.Teams;

        public IEnumerable<Bowler> GetBowlers()
        {
            var joinedData = from bowler in _bowlerContext.Bowlers
                             join team in _bowlerContext.Teams
                             on bowler.TeamID equals team.TeamID
                             select new
                             {
                                 BowlerID = bowler.BowlerID,
                                 BowlerFirstName = bowler.BowlerFirstName,
                                 BowlerLastName = bowler.BowlerLastName,
                                 BowlerMiddleInit = bowler.BowlerMiddleInit,
                                 BowlerAddress = bowler.BowlerAddress,
                                 BowlerCity = bowler.BowlerCity,
                                 BowlerState = bowler.BowlerState,
                                 BowlerZip = bowler.BowlerZip,
                                 BowlerPhoneNumber = bowler.BowlerPhoneNumber,
                                 TeamID = bowler.TeamID,
                                 TeamID2 = team.TeamID,
                                 TeamName = team.TeamName,
                             };

            var bowlersWithTeams = joinedData
                .Select(b => new Bowler
                {
                    BowlerID = b.BowlerID,
                    BowlerFirstName = b.BowlerFirstName,
                    BowlerLastName = b.BowlerLastName,
                    BowlerMiddleInit = b.BowlerMiddleInit,
                    BowlerAddress = b.BowlerAddress,
                    BowlerCity = b.BowlerCity,
                    BowlerState = b.BowlerState,
                    BowlerZip = b.BowlerZip,
                    BowlerPhoneNumber = b.BowlerPhoneNumber,
                    TeamID = b.TeamID,
                    Team = new Team { TeamName = b.TeamName, TeamID = b.TeamID2 }
                })
                .ToList();

            return bowlersWithTeams;
        }

        public void GetBowlers(Bowler bowler)
        {
            throw new NotImplementedException();
        }

    }
}
