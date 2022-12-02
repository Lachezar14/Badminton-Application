using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace LogicLayer.Interfaces
{
    public interface IAuthenticationManager
    {
        void ResetUsers();
        User GetPlayerByUsername(string username);
        User GetEmployeeByUsername(string username);
        int AuthenticatePlayer(string username,string password);
        int AuthenticateEmployee(string username, string password);
    }
}
