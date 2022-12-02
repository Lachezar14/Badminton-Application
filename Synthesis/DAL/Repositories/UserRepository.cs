using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Entities.ENums;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private string conn = "Server=studmysql01.fhict.local;Database=dbi477927;Uid=dbi477927;Pwd=lucho;";

        public User GetUser(int id)
        {
            string query = $"SELECT u.Id,u.FirstName,u.LastName,u.Email,u.PhoneNumber,u.AccountType,u.Username,u.Password,u.Wins,u.Losses FROM users u WHERE Id = @id ;";
            string query2 = $"SELECT u.Id,u.FirstName,u.LastName,u.Email,u.PhoneNumber,u.AccountType,u.Username,u.Password FROM users u WHERE Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            MySqlCommand command2 = new MySqlCommand(query2, myConn);

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                    User player = new Player(
                        myReader.GetInt32("Id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        Enum.Parse<AccountType>(myReader.GetString("AccountType")),
                        myReader.GetString("Username"),
                        myReader.GetString("Password"),
                        myReader.GetInt32("Wins"),
                        myReader.GetInt32("Losses")
                    );
                    return player;
                }
            }
            finally
            {
                myConn.Close();
            }

            try
            {
                myConn.Open();
                command2.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command2.ExecuteReader();

                if (myReader.Read())
                {
                    User employee = new Employee(
                        myReader.GetInt32("Id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        Enum.Parse<AccountType>(myReader.GetString("AccountType")),
                        myReader.GetString("Username"),
                        myReader.GetString("Password")
                    );
                    return employee;
                }
                return null;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<User> GetAllUsers()
        {
            string query = $"SELECT u.Id,u.FirstName,u.LastName,u.Email,u.PhoneNumber,u.AccountType,u.Username,u.Password,u.Wins,u.Losses FROM users u WHERE AccountType = @AccountType;";
            string query2 = $"SELECT u.Id,u.FirstName,u.LastName,u.Email,u.PhoneNumber,u.AccountType,u.Username,u.Password FROM users u WHERE AccountType = @AccountType;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            MySqlCommand command2 = new MySqlCommand(query2, myConn);
            List<User> users = new List<User>();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@AccountType", "Player");
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    User player = new Player(
                        myReader.GetInt32("Id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        Enum.Parse<AccountType>(myReader.GetString("AccountType")),
                        myReader.GetString("Username"),
                        myReader.GetString("Password"),
                        myReader.GetInt32("Wins"),
                        myReader.GetInt32("Losses")
                    );
                    users.Add(player);
                }
            }
            finally
            {
                myConn.Close();
            }

            try
            {
                myConn.Open();
                command2.Parameters.AddWithValue("@AccountType", "Employee");
                MySqlDataReader myReader = command2.ExecuteReader();

                while (myReader.Read())
                {
                    User employee = new Employee(
                        myReader.GetInt32("Id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        Enum.Parse<AccountType>(myReader.GetString("AccountType")),
                        myReader.GetString("Username"),
                        myReader.GetString("Password")
                    );
                    users.Add(employee);
                }
                return users;
            }
            finally
            {
                myConn.Close();
            }
        }

        public int GetPlayersWinsPerTournament(Tournament tournament, User player)
        {
            string query = $"SELECT COUNT(*) FROM matches WHERE(Tournament_Id = @tournament_Id AND Player1_Id = @player_Id AND Player1_Score > Player2_Score) OR (Tournament_Id = @tournament_Id AND Player2_Id = @player_Id AND Player2_Score > Player1_Score);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            int nrOfWins = 0;
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@tournament_Id", tournament.Id);
                command.Parameters.AddWithValue("@player_Id", player.Id);
                nrOfWins = (int)(long)command.ExecuteScalar();
                
                return (int)nrOfWins;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<User> GetPlayersPerTournament(int tournamentId)
        {
            string query = $"SELECT u.Id,u.FirstName,u.LastName,u.Email,u.PhoneNumber,u.AccountType,u.Username,u.Password,u.Wins,u.Losses FROM users u INNER JOIN tournamentplayers t ON u.Id = t.User_Id WHERE Tournament_Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            List<User> players = new List<User>();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", tournamentId);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    User player = new Player(
                        myReader.GetInt32("Id"),
                        myReader.GetString("FirstName"),
                        myReader.GetString("LastName"),
                        myReader.GetString("Email"),
                        myReader.GetString("PhoneNumber"),
                        Enum.Parse<AccountType>(myReader.GetString("AccountType")),
                        myReader.GetString("Username"),
                        myReader.GetString("Password"),
                        myReader.GetInt32("Wins"),
                        myReader.GetInt32("Losses")
                    );
                    players.Add(player);
                }

                return players;
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddPlayer(User user)
        {
            Player player = (Player)user;
            string query = $"INSERT INTO users (FirstName,LastName,Email,PhoneNumber,AccountType,Username,Password,Wins,Losses) VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@AccountType,@Username,@Password,@Wins,@Losses);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@FirstName", player.FName);
                command.Parameters.AddWithValue("@LastName", player.LName);
                command.Parameters.AddWithValue("@Email", player.Email);
                command.Parameters.AddWithValue("@PhoneNumber", player.Phone);
                command.Parameters.AddWithValue("@AccountType", player.Type.ToString());
                command.Parameters.AddWithValue("@Username", player.Username);
                command.Parameters.AddWithValue("@Password", player.Password);
                command.Parameters.AddWithValue("@Wins", player.Wins);
                command.Parameters.AddWithValue("@Losses", player.Losses);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddEmployee(User user)
        {
            Employee employee = (Employee)user;
            string query = $"INSERT INTO users (FirstName,LastName,Email,PhoneNumber,AccountType,Username,Password) VALUES (@FirstName,@LastName,@Email,@PhoneNumber,@AccountType,@Username,@Password);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@FirstName", employee.FName);
                command.Parameters.AddWithValue("@LastName", employee.LName);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@PhoneNumber", employee.Phone);
                command.Parameters.AddWithValue("@AccountType", employee.Type.ToString());
                command.Parameters.AddWithValue("@Username", employee.Username);
                command.Parameters.AddWithValue("@Password", employee.Password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void UpdateUser(User user)
        {
            string query= "UPDATE users SET FirstName = @FirstName, LastName = @LastName, Email = @Email, PhoneNumber = @PhoneNumber, AccountType = @AccountType, Username = @Username, Password = @Password WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@FirstName", user.FName);
                command.Parameters.AddWithValue("@LastName", user.LName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@PhoneNumber", user.Phone);
                command.Parameters.AddWithValue("@AccountType", user.Type.ToString());
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void UpdateUserPassword(User user,string password)
        {
            string query = $"UPDATE users SET Password = @Password WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", user.Id);
                command.Parameters.AddWithValue("@Password", password);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void DeleteUser(int id)
        {
            string query = $"DELETE FROM users WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void IsWinner(User user)
        {
            Player player = (Player)user;
            string query = $"UPDATE users SET Wins = @Wins WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Wins", player.Wins);
                command.Parameters.AddWithValue("@Id", player.Id);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }

        public void IsLoser(User user)
        {
            Player player = (Player)user;
            string query = $"UPDATE users SET Losses = @Losses WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Losses", player.Losses);
                command.Parameters.AddWithValue("@Id", player.Id);
                MySqlDataReader myReader = command.ExecuteReader();

                if (myReader.Read())
                {
                }
            }
            finally
            {
                myConn.Close();
            }
        }
    }
}
