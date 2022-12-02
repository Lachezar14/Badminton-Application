using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface ITournamentRepository
    {
        Tournament GetTournament(int id);
        List<Tournament> GetAllTournaments();
        List<Tournament> GetAllTournamentsPerPlayer(User user);
        void AddTournament(Tournament tournament);
        void AddPlayerToTournament(Tournament tournament, User player);
        void RemovePlayerFromTournament(Tournament tournament, User player);
        void UpdateTournament(Tournament tournament);
        void DeleteTournament(int id);
    }
}
