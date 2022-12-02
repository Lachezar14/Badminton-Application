using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.ENums;

namespace Entities
{
    public class User
    {
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }

        public string FName
        {
            get { return _fName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First Name cannot be empty");
                }
                if (!value.All(char.IsLetter))
                {
                    throw new ArgumentException("First Name must not contain digits");
                }
                _fName = value;
            }
        }

        public string LName
        {
            get { return _lName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last Name cannot be empty");
                }
                if (!value.All(char.IsLetter))
                {
                    throw new ArgumentException("Last Name must not contain digits");
                }
                _lName = value;
            }
        }

        public string Email
        {
            get { return _email;}
            private set
            {
                _email = value;
            }
        }

        public string Phone
        {
            get { return _phone;}
            private set
            {
                _phone = value;
            }
        }

        public AccountType Type
        {
            get { return _type;}
            private set
            {
                _type = value;
            }
        }

        public string Username
        {
            get { return _username;}
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Username cannot be empty.");
                }
                _username = value;
            }
        }

        public string Password
        {
            get { return _password;}
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Password cannot be empty.");
                }
                _password = value;
            }
        }

        public User(){}

        public User(int id,string fName, string lName, string email, string phone, AccountType type, string username, string password)
        {
            Id = id;
            FName = fName;
            LName = lName;
            Email = email;
            Phone = phone;
            Type = type;
            Username = username;
            Password = password;
        }

        public User(string fName, string lName, string email, string phone, AccountType type, string username, string password)
        {
            FName = fName;
            LName = lName;
            Email = email;
            Phone = phone;
            Type = type;
            Username = username;
            Password = password;
        }

        public User(PlayerDTO playerDto)
        {
            this.Id = playerDto.Id;
            this.FName = playerDto.FName;
            this.LName = playerDto.LName;
            this.Email = playerDto.Email;
            this.Phone = playerDto.Phone;
            this.Type = playerDto.Type;
            this.Username = playerDto.Username;
            this.Password = playerDto.Password;
        }

        public void UpdatePassword(string password)
        {
            this.Password = password;
        }

        public override string ToString()
        {
            return $"{FName} {LName}";
        }

        private int _id;
        private string _fName;
        private string _lName;
        private string _email;
        private string _phone;
        private AccountType _type;
        private string _username;
        private string _password;
        
        public override bool Equals(Object obj)
        {
            if (obj is User that)
            {
                return Id == that.Id && FName == that.FName && LName == that.LName && Email == that.Email && Phone == that.Phone &&
                       Type == that.Type && Username == that.Username && Password == that.Password;
            }
            return false;
        }
    }
}
