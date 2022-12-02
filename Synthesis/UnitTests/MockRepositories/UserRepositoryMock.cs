using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;

namespace UnitTests.MockRepositories
{
    public class UserRepositoryMock : IUserRepository
    {
        public User GetUser(int id)
        {
            return null;
        }

        public List<User> GetAllUsers()
        {
            return new List<User>();
        }

        public int GetPlayersWinsPerTournament(Tournament tournament, User player)
        {
            return 0;
        }

        public List<User> GetPlayersPerTournament(int tournamentId)
        {
            return new List<User>();
        }
        public void AddPlayer(User user){}
        public void AddEmployee(User user){}
        public void UpdateUser(User user){}
        public void UpdateUserPassword(User user,string password){}
        public void DeleteUser(int id){}
        public void IsWinner(User user){}
        public void IsLoser(User user){}
    }
}
