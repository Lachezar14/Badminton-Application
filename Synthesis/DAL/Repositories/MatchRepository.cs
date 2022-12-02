using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using MySql.Data.MySqlClient;

namespace DAL.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private string conn = "Server=studmysql01.fhict.local;Database=dbi477927;Uid=dbi477927;Pwd=lucho;";

        public AMatch GetMatch(int id)
        {
            
            string query = $"SELECT m.Id,m.Tournament_Id,m.Player1_Id,m.Player2_Id,m.Player1_Score,m.Player2_Score,m.Round FROM matches m WHERE Id = @id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            UserRepository userRepository = new UserRepository();
            TournamentRepository tournamentRepository = new TournamentRepository();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {

                    int player1Id = myReader.GetInt32("Player1_Id");
                    int player2Id = myReader.GetInt32("Player2_Id");
                    int tournamentId = myReader.GetInt32("Tournament_Id");


                    AMatch match = new (

                        myReader.GetInt32("Id"),
                        tournamentRepository.GetTournament(tournamentId),
                        userRepository.GetUser(player1Id),
                        userRepository.GetUser(player2Id),
                        myReader.GetInt32("Player1_Score"),
                        myReader.GetInt32("Player2_Score"),
                        myReader.GetInt32("Round")
                    );
                    return match;
                }
                return null;
            }
            finally
            {
                myConn.Close();
            }
        }

        public AMatch GetMatchByPlayersAndTournament(int tournamentId, int playe1Id, int player2Id)
        {
            string query = $"SELECT m.Id,m.Tournament_Id,m.Player1_Id,m.Player2_Id,m.Player1_Score,m.Player2_Score,m.Round FROM matches m WHERE Tournament_Id = @tournament_Id AND Player1_Id = @player1_Id AND Player2_Id = @player2_Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            UserRepository userRepository = new UserRepository();
            TournamentRepository tournamentRepository = new TournamentRepository();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@tournament_Id", tournamentId);
                command.Parameters.AddWithValue("@player1_Id", playe1Id);
                command.Parameters.AddWithValue("@player2_Id", player2Id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {

                    int p1Id = myReader.GetInt32("Player1_Id");
                    int p2Id = myReader.GetInt32("Player2_Id");
                    int tId = myReader.GetInt32("Tournament_Id");


                    AMatch match = new(

                        myReader.GetInt32("Id"),
                        tournamentRepository.GetTournament(tId),
                        userRepository.GetUser(p1Id),
                        userRepository.GetUser(p2Id),
                        myReader.GetInt32("Player1_Score"),
                        myReader.GetInt32("Player2_Score"),
                        myReader.GetInt32("Round")
                    );
                    return match;
                }
                return null;
            }
            finally
            {
                myConn.Close();
            }
        }


        public List<AMatch> GetAllMatches()
        {
            string query = "SELECT m.Id,m.Tournament_Id,m.Player1_Id,m.Player2_Id,m.Player1_Score,m.Player2_Score,m.Round FROM matches m ;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            UserRepository userRepository = new UserRepository();
            TournamentRepository tournamentRepository = new TournamentRepository();
            List<AMatch> matches = new List<AMatch>();

            try
            {
                myConn.Open();
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    int player1_Id = myReader.GetInt32("Player1_Id");
                    int player2_Id = myReader.GetInt32("Player2_Id");
                    int tournamentId = myReader.GetInt32("Tournament_Id");

                    AMatch match = new(

                            myReader.GetInt32("Id"),
                            tournamentRepository.GetTournament(tournamentId),
                            userRepository.GetUser(player1_Id),
                            userRepository.GetUser(player2_Id),
                            myReader.GetInt32("Player1_Score"),
                            myReader.GetInt32("Player2_Score"),
                            myReader.GetInt32("Round")
                    );
                    matches.Add(match);
                }
                return matches;
            }
            finally
            {
                myConn.Close();
            }
        }

        public List<AMatch> GetAllMatchesPerTournament(Tournament tournament)
        {
            string query = "SELECT m.Id,m.Tournament_Id,m.Player1_Id,m.Player2_Id,m.Player1_Score,m.Player2_Score,m.Round FROM matches m WHERE Tournament_Id = @id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            UserRepository userRepository = new UserRepository();
            TournamentRepository tournamentRepository = new TournamentRepository();
            List<AMatch> matches = new List<AMatch>();

            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@id", tournament.Id);
                MySqlDataReader myReader = command.ExecuteReader();

                while (myReader.Read())
                {
                    int player1_Id = myReader.GetInt32("Player1_Id");
                    int player2_Id = myReader.GetInt32("Player2_Id");
                    int tournamentId = myReader.GetInt32("Tournament_Id");


                    AMatch match = new(

                        myReader.GetInt32("Id"),
                        tournamentRepository.GetTournament(tournamentId),
                        userRepository.GetUser(player1_Id),
                        userRepository.GetUser(player2_Id),
                        myReader.GetInt32("Player1_Score"),
                        myReader.GetInt32("Player2_Score"),
                        myReader.GetInt32("Round")
                    );
                    matches.Add(match);
                }
                return matches;
            }
            finally
            {
                myConn.Close();
            }
        }

        public void AddMatch(AMatch match)
        {
            string query = "INSERT INTO matches(Tournament_Id,Player1_Id,Player2_Id,Player1_Score,Player2_Score,Round) VALUES (@Tournament_Id,@Player1_Id,@Player2_Id,@Player1_Score,@Player2_Score,@Round);";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Tournament_Id", match.Tournament.Id);
                command.Parameters.AddWithValue("@Player1_Id", match.Player1.Id);
                command.Parameters.AddWithValue("@Player2_Id", match.Player2.Id);
                command.Parameters.AddWithValue("@Player1_Score", match.Player1_Score);
                command.Parameters.AddWithValue("@Player2_Score", match.Player2_Score);
                command.Parameters.AddWithValue("@Round", match.Round);

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

        public void UpdateMatch(AMatch match)
        {
            string query = $"UPDATE matches m SET Tournament_Id = @Tournament_Id ,Player1_Id = @Player1_Id,Player2_Id = @Player2_Id ,Player1_Score = @Player1_Score,Player2_Score = @Player2_Score,Round = @Round WHERE Id = @Id;";
            MySqlConnection myConn = new MySqlConnection(conn);
            MySqlCommand command = new MySqlCommand(query, myConn);
            try
            {
                myConn.Open();
                command.Parameters.AddWithValue("@Id", match.Id);
                command.Parameters.AddWithValue("@Tournament_Id", match.Tournament.Id);
                command.Parameters.AddWithValue("@Player1_Id", match.Player1.Id);
                command.Parameters.AddWithValue("@Player2_Id", match.Player2.Id);
                command.Parameters.AddWithValue("@Player1_Score", match.Player1_Score);
                command.Parameters.AddWithValue("@Player2_Score", match.Player2_Score);
                command.Parameters.AddWithValue("@Round", match.Round);
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

        public void DeleteMatch(int id)
        {
            string query = "DELETE FROM matches WHERE Id = @Id;";
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
