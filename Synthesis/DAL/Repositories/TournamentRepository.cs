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
    public class TournamentRepository : ITournamentRepository
    {
        private string conn = "Server=studmysql01.fhict.local;Database=dbi477927;Uid=dbi477927;Pwd=lucho;";

        public Tournament GetTournament(int tournamentId)
        {
            string query = $"SELECT t.Id,t.SportType,t.Description,t.Location,t.TournamentType,t.StartDate,t.EndDate,t.MinPlayers,t.MaxPlayers FROM tournaments t WHERE Id = @id ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            UserRepository userRepository = new UserRepository();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", tournamentId);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    var type = Enum.Parse<TournamentType>(myReader.GetString("TournamentType"));
                    if (type == TournamentType.RoundRobin)
                    {
                        Tournament tournament = new RoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournament.Players = userRepository.GetPlayersPerTournament(tournamentId);
                        return tournament;
                    }
                    else if (type == TournamentType.DoubleRoundRobin)
                    {
                        Tournament tournament = new DoubleRoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournament.Players = userRepository.GetPlayersPerTournament(tournamentId);
                        return tournament;
                    }
                }
                return null;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<Tournament> GetAllTournaments()
        {
            string query = $"SELECT t.Id,t.SportType,t.Description,t.Location,t.TournamentType,t.StartDate,t.EndDate,t.MinPlayers,t.MaxPlayers FROM tournaments t;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            List<Tournament> tournaments = new List<Tournament>();
            UserRepository userRepository = new UserRepository();

            try
            {
                myConn.Open();
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    var type = Enum.Parse<TournamentType>(myReader.GetString("TournamentType"));
                    if (type == TournamentType.RoundRobin)
                    {
                        Tournament tournament = new RoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournaments.Add(tournament);
                    }
                    else if (type == TournamentType.DoubleRoundRobin)
                    {
                        Tournament tournament = new DoubleRoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournaments.Add(tournament);
                    }
                }

                foreach (Tournament tournament in tournaments)
                {
                    tournament.Players = userRepository.GetPlayersPerTournament(tournament.Id);
                }
                return tournaments;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<Tournament> GetAllTournamentsPerPlayer(User user)
        {
            string query = $"Select t.Id,t.SportType,t.Description,t.Location,t.TournamentType,t.StartDate,t.EndDate,t.MinPlayers,t.MaxPlayers FROM tournaments t INNER JOIN tournamentplayers p ON t.Id = p.Tournament_Id WHERE p.User_Id = @User_Id";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            List<Tournament> tournaments = new List<Tournament>();
            UserRepository userRepository = new UserRepository();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@User_Id", user.Id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    var type = Enum.Parse<TournamentType>(myReader.GetString("TournamentType"));
                    if (type == TournamentType.RoundRobin)
                    {
                        Tournament tournament = new RoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournaments.Add(tournament);
                    }
                    else if (type == TournamentType.DoubleRoundRobin)
                    {
                        Tournament tournament = new DoubleRoundRobin(
                            myReader.GetInt32("Id"),
                            Enum.Parse<SportType>(myReader.GetString("SportType")),
                            myReader.GetString("Description"),
                            myReader.GetString("Location"),
                            type,
                            myReader.GetDateTime("StartDate"),
                            myReader.GetDateTime("EndDate"),
                            myReader.GetInt32("MinPlayers"),
                            myReader.GetInt32("MaxPlayers")
                        );
                        tournaments.Add(tournament);
                    }
                }

                foreach (Tournament tournament in tournaments)
                {
                    tournament.Players = userRepository.GetPlayersPerTournament(tournament.Id);
                }
                return tournaments;
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddTournament(Tournament tournament)
        {
            string query = "INSERT INTO tournaments (SportType,Description,Location,TournamentType,StartDate,EndDate,MinPlayers,MaxPlayers) VALUES (@SportType,@Description,@Location,@TournamentType,@StartDate,@EndDate,@MinPlayers,@MaxPlayers);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@SportType", tournament.SportType.ToString());
                command.Parameters.AddWithValue("@Description", tournament.Description);
                command.Parameters.AddWithValue("@Location", tournament.Location);
                command.Parameters.AddWithValue("@TournamentType", tournament.TournamentType.ToString());
                command.Parameters.AddWithValue("@StartDate", tournament.StartDate);
                command.Parameters.AddWithValue("@EndDate", tournament.EndDate);
                command.Parameters.AddWithValue("@MinPlayers", tournament.MinPlayers);
                command.Parameters.AddWithValue("@MaxPlayers", tournament.MaxPlayers);
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

        public void AddPlayerToTournament(Tournament tournament, User player)
        {
            string query = "INSERT INTO tournamentplayers (Tournament_Id,User_Id) VALUES (@tournament_Id,@user_Id);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@tournament_Id", tournament.Id);
                command.Parameters.AddWithValue("@user_Id", player.Id);
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

        public void RemovePlayerFromTournament(Tournament tournament, User player)
        {
            string query = "DELETE FROM tournamentplayers WHERE Tournament_Id = @tournament_Id AND User_Id = @user_Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@tournament_Id", tournament.Id);
                command.Parameters.AddWithValue("@user_Id", player.Id);
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

        public void UpdateTournament(Tournament tournament)
        {
            string query = "UPDATE tournaments SET SportType = @SportType,Description=@Description,Location=@Location,TournamentType=@TournamentType,StartDate=@StartDate,EndDate=@EndDate,MinPlayers=@MinPlayers,MaxPlayers=@MaxPlayers WHERE Id=@Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", tournament.Id);
                command.Parameters.AddWithValue("@SportType", tournament.SportType.ToString());
                command.Parameters.AddWithValue("@Description", tournament.Description);
                command.Parameters.AddWithValue("@Location", tournament.Location);
                command.Parameters.AddWithValue("@TournamentType", tournament.TournamentType.ToString());
                command.Parameters.AddWithValue("@StartDate", tournament.StartDate);
                command.Parameters.AddWithValue("@EndDate", tournament.EndDate);
                command.Parameters.AddWithValue("@MinPlayers", tournament.MinPlayers);
                command.Parameters.AddWithValue("@MaxPlayers", tournament.MaxPlayers);
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

        public void DeleteTournament(int id)
        {
            string query = "DELETE FROM tournaments WHERE Id=@Id;";
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
    }
}
