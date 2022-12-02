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
    public class TournamentTesting
    {
        [TestMethod]
        public void GetTournamentId()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            int actual = tournament.Id;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentSportType()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.SportType.ToString();
            string expected = SportType.Badminton.ToString();
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentDescription()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.Description;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentLocation()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.Location;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentTournamentType()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.TournamentType.ToString();
            string expected = TournamentType.RoundRobin.ToString();
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentStartDate()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.StartDate.ToString();
            string expected = DateTime.Now.ToString();
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentEndDate()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            string actual = tournament.EndDate.ToString();
            string expected = DateTime.Now.ToString();
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentMinPlayers()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            int actual = tournament.MinPlayers;
            int expected = 2;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentMaxPlayers()
        {
            Tournament tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            int actual = tournament.MaxPlayers;
            int expected = 10;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetTournamentListOfPlayers()
        {
            List<User> expected = new List<User>();
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            expected.Add(user1);
            expected.Add(user2);
            expected.Add(user3);
            expected.Add(user4);
            List<User> actual = new List<User>();
            actual.Add(user1);
            actual.Add(user2);
            actual.Add(user3);
            actual.Add(user4);
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10,actual);
            CollectionAssert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongIdTournament()
        {
            var tournament = new RoundRobin(-1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullDescription()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, null, "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullLocation()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", null, TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongEndDate()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, (DateTime.Now).AddDays(-1), 2, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongMinPlayers()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongMaxPlayers()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 3, 52);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongMaxPlayers2()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 3, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongListOfPlayers()
        {
            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            List<User> players = new List<User>();
            players.Add(user1);
            players.Add(user2);
            players.Add(user3);
            players.Add(user4);
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 3,players);
        }
    }
}
