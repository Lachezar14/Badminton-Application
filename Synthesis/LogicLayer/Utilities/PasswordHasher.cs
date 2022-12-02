using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Utilities
{
    public class PasswordHasher
    {
        //Method to hash the password and store the hash in the database
        public string HashPassword(string password)
        {
            //Creating the salt value with a cryptographic PRNG(Pseudo Random Number Generator)
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            //Creates the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            //Combines the salt and password bytes:
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            //Turns the combined salt+hash into a string for storage
            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            return savedPasswordHash;
        }

        //Method to verify the user-entered password against a stored password
        public bool ValidateHashedPassword(string input, string hashedPassword)
        {
            if (hashedPassword == "unknown password") return false;
            
            //Converts the stored password back from a string
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            
            //Adds salt to the inputted password so that then it could be compared to the stored password
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            //Creates the Rfc2898DeriveBytes and get the hash value:
            var pbkdf2 = new Rfc2898DeriveBytes(input, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            
            //Compares the 2 password bytes
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    return false;
            return true;
        }
    }
}
