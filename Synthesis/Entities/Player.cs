using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.DTOs;
using Entities.ENums;

namespace Entities
{
    public class Player : User
    {
        public int Wins { get; private set; }
        public int Losses { get; private set; }

        public Player(){}

        public Player(PlayerDTO playerDto) : base(playerDto.Id,playerDto.FName,
            playerDto.LName, playerDto.Email, playerDto.Phone,playerDto.Type,playerDto.Username,playerDto.Password)
        {
            Wins = playerDto.Wins;
            Losses = playerDto.Losses;
        }

        public Player(int id, string fName, string lName, string email, string phone, AccountType type, string username, string password,
            int wins, int losses) : base(id, fName, lName, email, phone, type, username, password)
        {
            Wins = wins;
            Losses = losses;
        }

        public Player(string fName, string lName, string email, string phone, AccountType type, string username, string password,
            int wins, int losses) : base(fName, lName, email, phone, type, username, password)
        {
            Wins = wins;
            Losses = losses;
        }

        public void IsWinner()
        {
            this.Wins++;
        }

        public void IsLoser()
        {
            this.Losses++;
        }

        public override string ToString()
        {
            return base.ToString();
        }
        
        public override bool Equals(Object obj)
        {
            if (obj is Player that)
            {
                return Id == that.Id && FName == that.FName && LName == that.LName && Email == that.Email && Phone == that.Phone &&
                       Type == that.Type && Username == that.Username && Password == that.Password && Wins == that.Wins && Losses == that.Losses;
            }
            return false;
        }
    }
}
