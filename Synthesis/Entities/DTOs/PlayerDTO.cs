using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ENums;

namespace Entities.DTOs
{
    public class PlayerDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter your first name")]
        public string FName { get; set; }
        
        [Required(ErrorMessage = "Please enter your last name")]
        public string LName { get; set; }
        
        [Required(ErrorMessage = "Please enter your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Write a valid Email")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Please enter your phone number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Write valid Phone Number")]
        public string Phone { get; set; }
        
        public AccountType Type { get; set; }

        [Required(ErrorMessage = "Please enter your username")]
        public string Username { get; set; }
        
        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    }
}
