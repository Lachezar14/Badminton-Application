using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ENums;

namespace Entities
{
    public  class Employee : User
    {
        public Employee(int id, string fName, string lName, string email, string phone, AccountType type, string username, string password) :
            base(id, fName, lName, email, phone, type, username, password)
        {
        }

        public Employee(string fName, string lName, string email, string phone, AccountType type, string username, string password) :
            base(fName, lName, email, phone, type, username, password)
        {
        }

        public override string ToString()
        {
            return $"{base.ToString()} ({Type})";
        }
    }
}
