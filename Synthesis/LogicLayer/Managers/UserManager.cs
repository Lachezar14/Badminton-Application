using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Entities.ENums;
using LogicLayer.Interfaces;

namespace LogicLayer.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;
        private List<User> users;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            users = _userRepository.GetAllUsers();
        }

        public void ResetAllUsers()
        {
            users = _userRepository.GetAllUsers();
        }

        public User GetUser(int id)
        {
            foreach (User user in users)
            {
                if (user.Id == id)
                {
                    return user;
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public int GetPlayersWinsPerTournament(Tournament tournament, User player)
        {
            return _userRepository.GetPlayersWinsPerTournament(tournament, player);
        }

        public List<User> GetAllPlayersPerTournament(int tournamentId)
        {
            return _userRepository.GetPlayersPerTournament(tournamentId);
        }

        public void AddUser(User user)
        {
            if (users.Contains(user))
            {
                throw new ArgumentException("User already exists");
            }
            else if (users.Find(u => u.Username == user.Username) != null)
            {
                throw new ArgumentException("User with that username already exists");
            }
            else if (users.Find(u => u.Password == user.Password) != null)
            {
                throw new ArgumentException("User with that password already exists");
            }
            else
            {
                if (user.Type == AccountType.Player)
                {
                    users.Add(user);
                    _userRepository.AddPlayer(user);
                }
                else if (user.Type == AccountType.Employee)
                {
                    users.Add(user);
                    _userRepository.AddEmployee(user);
                }
            }
        }

        public void UpdateUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentException("User cannot be null");
            }
            if (users.Find(u => u.Id == user.Id) == null)
            {
                throw new ArgumentException("User does not exist");
            }
            else
            {
                _userRepository.UpdateUser(user);

                int index = users.FindIndex(u => u.Id == user.Id);
                if (index >= 0)
                {
                    users[index] = user;
                }
            }
        }

        public void UpdateUserPassword(User user,string password)
        {
            if (users.Find(u => u.Password == password) != null)
            {
                throw new ArgumentException("Password already in use");
            }
            else
            {
                user.UpdatePassword(password);
                UpdateUser(user);
                _userRepository.UpdateUserPassword(user,password);
            }
        }

        public void DeleteUser(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Id cannot be negative");
            }
            else
            {
                users.Remove(GetUser(id));
                _userRepository.DeleteUser(id);
            }
        }

        public void IsWinner(User user)
        {
            Player player = (Player)user;
            
            player.IsWinner();
            _userRepository.IsWinner(player);
        }

        public void IsLoser(User user)
        {
            Player player = (Player)user;

            player.IsLoser();
            _userRepository.IsLoser(player);
        }
    }
}
