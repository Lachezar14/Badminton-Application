using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer.Interfaces
{
    public interface ITournamentManager
    {
         void ResetAllTournaments();
         Tournament GetTournament(int id);
         List<Tournament> GetAllTournaments();
         List<Tournament> GetAllTournamentsPerPlayer(User user);
         void CreateSchedule(Tournament tournament);
         void AddTournament(Tournament tournament);
         void AddPlayerToTournament(Tournament tournament, User player);
         void RemovePlayerFromTournament(Tournament tournament, User player);
         void UpdateTournament(Tournament tournament);
         void DeleteTournament(int id);
         bool TournamentLocked(Tournament tournament);
         bool TournamentNotPlayed(Tournament tournament);

    }
}
