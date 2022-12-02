using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Entities.ENums;
using LogicLayer.Interfaces;
using LogicLayer.Utilities;

namespace LogicLayer.Managers
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IUserRepository _userRepository;
        private List<User> users;
        private PasswordHasher _passwordHasher = new PasswordHasher();
        private IUserManager _userManager;


        public AuthenticationManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userManager = new UserManager(userRepository);
            users = _userManager.GetAllUsers();
        }
        public AuthenticationManager(IUserRepository userRepository, UserManager userManager) // this overload is for unit testing purposes
        {
            _userRepository = userRepository;
            _userManager = userManager;
            users = _userManager.GetAllUsers();
        }
        


        public void ResetUsers()
        {
            users = _userManager.GetAllUsers();
        }

        public User GetPlayerByUsername(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Type == AccountType.Player)
                {
                    return user;
                }
            }
            return null;
        }

        public User GetEmployeeByUsername(string username)
        {
            foreach (User user in users)
            {
                if (user.Username == username && user.Type == AccountType.Employee)
                {
                    return user;
                }
            }
            return null;
        }

        public int AuthenticatePlayer(string username, string enteredPassword)
        {
            User user = GetPlayerByUsername(username);
            if (user != null)
            {
                if (_passwordHasher.ValidateHashedPassword(enteredPassword, user.Password))
                {
                    return user.Id;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }

        public int AuthenticateEmployee(string username, string enteredPassword)
        {
            User user = GetEmployeeByUsername(username);
            if (user != null)
            {
                if (_passwordHasher.ValidateHashedPassword(enteredPassword, user.Password))
                {
                    return user.Id;
                }
                else
                {
                    return -1;
                }
            }
            return -1;
        }
    }
}
