using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.ENums;

namespace UnitTests.EntitiesTesting
{
    [TestClass]
    public class AMatchTesting
    {
        [TestMethod]
        public void GetMatchId()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            int actual = match.Id;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            var actual = match.Tournament;
            var expected = tournament;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchPlayer1()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            var actual = match.Player1;
            var expected = player1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchPlayer2()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            var actual = match.Player2;
            var expected = player2;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchPlayer1Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 21, 7, 1);
            int actual = match.Player1_Score;
            int expected = 21;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchPlayer2Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 21, 7, 1);
            int actual = match.Player2_Score;
            int expected = 7;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetMatchRound()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            AMatch match = new AMatch(1, tournament, player1, player2, 21, 7, 1);
            int actual = match.Round;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongId()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(-1, tournament, player1, player2, 0, 0, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongRound()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongWinnerPlayer1Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            expected.Result(19,18);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNegativePlayer1Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0,0 , 1);
            expected.Result(-1, 18);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPlayer1ScoreMoreThan30()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            expected.Result(33, 18);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongWinnerPlayer2Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            expected.Result(15, 18);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNegativePlayer2Score()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            expected.Result(12, -2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPlayer2ScoreMoreThan30()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            expected.Result(19, 33);
        }
    }
}
