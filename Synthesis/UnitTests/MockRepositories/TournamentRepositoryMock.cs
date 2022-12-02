using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace UnitTests.MockRepositories
{
    public class TournamentRepositoryMock : ITournamentRepository
    {
        public Tournament GetTournament(int id)
        {
            return null;
        }

        public List<Tournament> GetAllTournaments()
        {
            return new List<Tournament>();
        }

        public List<Tournament> GetAllTournamentsPerPlayer(User user)
        {
            return new List<Tournament>();
        }
        public void AddTournament(Tournament tournament){}
        public void AddPlayerToTournament(Tournament tournament, User player){}
        public void RemovePlayerFromTournament(Tournament tournament, User player){}
        public void UpdateTournament(Tournament tournament){}
        public void DeleteTournament(int id){}
    }
}
