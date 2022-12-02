using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer.Interfaces
{
    public interface IUserManager
    {
        void ResetAllUsers();
        User GetUser(int id);
        List<User> GetAllUsers();
        int GetPlayersWinsPerTournament(Tournament tournament, User player);
        List<User> GetAllPlayersPerTournament(int tournamentId);
        void AddUser(User user);
        void UpdateUser(User user);
        void UpdateUserPassword(User user,string password);
        void DeleteUser(int id);
        void IsWinner(User user);
        void IsLoser(User user);
    }
}
