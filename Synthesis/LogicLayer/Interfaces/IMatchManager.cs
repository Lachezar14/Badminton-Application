using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer.Interfaces
{
    public interface IMatchManager
    {
         AMatch GetMatch(int id);
         AMatch GetMatchByPlayersAndTournament(int tournament_Id, int playe1_Id, int player2_Id);
         List<AMatch> GetAllMatches();
         List<AMatch> GetAllMatchesPerTournament(Tournament tournament);
         void AddMatch(AMatch match);
         //void AddResult(AMatch match, int player1_Score,int player2_Score);
         void UpdateMatch(AMatch match);
         void DeleteMatch(int id);
    }
}
