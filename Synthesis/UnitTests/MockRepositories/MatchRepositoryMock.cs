using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace UnitTests.MockRepositories
{
    public class MatchRepositoryMock : IMatchRepository
    {
        public AMatch GetMatch(int id)
        {
            return null;
        }

        public AMatch GetMatchByPlayersAndTournament(int tournament_Id, int playe1_Id, int player2_Id)
        {
            return null;
        }

        public List<AMatch> GetAllMatches()
        {
            return new List<AMatch>();
        }

        public List<AMatch> GetAllMatchesPerTournament(Tournament tournament)
        {
            return new List<AMatch>();
        }
        public void AddMatch(AMatch match){}
        public void UpdateMatch(AMatch match){}
        public void DeleteMatch(int id){}
    }
}
