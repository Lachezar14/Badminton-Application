using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);
        List<User> GetAllUsers();
        int GetPlayersWinsPerTournament(Tournament tournament, User player);
        List<User> GetPlayersPerTournament(int tournamentId);
        void AddPlayer(User user);
        void AddEmployee(User user);
        void UpdateUser(User user);
        void UpdateUserPassword(User user,string password);
        void DeleteUser(int id);
        void IsWinner(User user);
        void IsLoser(User user);
    }
}
