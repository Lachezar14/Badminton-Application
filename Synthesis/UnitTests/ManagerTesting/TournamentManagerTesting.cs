using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Entities.ENums;
using LogicLayer.Managers;
using UnitTests.MockRepositories;

namespace UnitTests.ManagerTesting
{
    [TestClass]
    public class TournamentManagerTesting
    {
        private TournamentManager _tournamentManager;
        private MatchManager _matchManager;

        public TournamentManagerTesting()
        {
            ITournamentRepository tournamentRepository;
            IMatchRepository matchRepository;
            tournamentRepository = new TournamentRepositoryMock();
            matchRepository = new MatchRepositoryMock();
            _tournamentManager = new TournamentManager(tournamentRepository,matchRepository);
            _matchManager = new MatchManager(matchRepository);
        }

        [TestMethod]
        public void GetTournament()
        {
            var expected = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(expected);
            var actual = _tournamentManager.GetTournament(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetAllTournaments()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var t2 = new RoundRobin(2, SportType.Badminton, "bxsaxasla", "baxsxala", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            List<Tournament> expected= new List<Tournament>();
            expected.Add(t1);
            expected.Add(t2);
            _tournamentManager.AddTournament(t1);
            _tournamentManager.AddTournament(t2);
            List<Tournament> actual = _tournamentManager.GetAllTournaments();
            CollectionAssert.AreEqual(expected,actual);
        }

        
        //The Schedule Algorithm is tested in a different class (ScheduleTesting)
        /*
        public void CreateSchedule()
        {
        }
        */
        
        [TestMethod]
        public void AddTournament()
        {
            var expected = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(expected);
            var actual = _tournamentManager.GetTournament(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameTournament()
        {
            var t1 = new RoundRobin( 1,SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var t2 = new RoundRobin( 1,SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(t1);
            _tournamentManager.AddTournament(t2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullTournament()
        {
            Tournament t1 = null;
            _tournamentManager.AddTournament(t1);
        }

        [TestMethod]
        public void AddPlayerToTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            User user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament,user);
            var tournament2 = _tournamentManager.GetTournament(1);
            Assert.IsTrue(tournament2.Players.Contains(user));
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullPlayerToTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            Player user = null;
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament,user);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddPlayerToFullTournament()
        {
            List<User> players = new List<User>();
            User user1 = new Player();
            User user2 = new Player();
            User user3 = new Player();
            players.Add(user1);
            players.Add(user2);
            players.Add(user3);
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 3,players);
            User player = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament,player);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSamePlayerToTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            User user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament, user);
            _tournamentManager.AddPlayerToTournament(tournament,user);
        }

        [TestMethod]
        public void RemovePlayerFromTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            User user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            User user2 = new Player(2, "blaxsasa", "bxsasala", "bxsaasxla@g.com", "32434453141", AccountType.Player, "blsxasxa", "603254", 0, 0);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament, user);
            _tournamentManager.AddPlayerToTournament(tournament,user2);
            _tournamentManager.RemovePlayerFromTournament(tournament,user);
            var tournament2 = _tournamentManager.GetTournament(1);
            Assert.IsFalse(tournament2.Players.Contains(user));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemovePlayerFromTournamentHeIsNotIn()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            User user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            User user2 = new Player(2, "blaxsasa", "bxsasala", "bxsaasxla@g.com", "32434453141", AccountType.Player, "blsxasxa", "603254", 0, 0);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.RemovePlayerFromTournament(tournament, user2);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNullPlayerFromTournament()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            Player user = null;
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.RemovePlayerFromTournament(tournament, user);
        }

        [TestMethod]
        public void UpdateTournament()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(t1);
            var expected = new RoundRobin(1, SportType.Badminton, "bscascla", "basccla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 12);
            _tournamentManager.UpdateTournament(expected);
            var actual = _tournamentManager.GetTournament(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateNullTournament()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(t1);
            var t2 = new RoundRobin(2, SportType.Badminton, "blaxx", "basccla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 12);
            _tournamentManager.UpdateTournament(t2);
        }
        
        [TestMethod]
        public void DeleteTournament()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(t1);
            _tournamentManager.DeleteTournament(1);
            var t2 = _tournamentManager.GetTournament(1);
            Assert.IsNull(t2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteTournamentInvalid()
        {
            _tournamentManager.DeleteTournament(-1);
        }

        [TestMethod]
        public void TournamentLocked()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(tournament);
            Assert.IsTrue(_tournamentManager.TournamentLocked(tournament));
        }
        
        [TestMethod]
        public void TournamentNotLocked()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Today.AddDays(10), DateTime.Today.AddDays(20), 2, 10);
            _tournamentManager.AddTournament(tournament);
            Assert.IsFalse(_tournamentManager.TournamentLocked(tournament));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TournamentNullLocked()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var t2 = new RoundRobin(2, SportType.Badminton, "blaca", "blacsca", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(t1);
            _tournamentManager.TournamentLocked(t2);
        }

        [TestMethod]
        public void TournamentNotPlayed()
        {
            var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 3, 10);
            _tournamentManager.AddTournament(t1);
            User user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            User user2 = new Player(2, "blaxsasa", "bxsasala", "bxsaasxla@g.com", "32434453141", AccountType.Player, "blsxasxa", "603254", 0, 0);
            _tournamentManager.AddPlayerToTournament(t1, user);
            _tournamentManager.AddPlayerToTournament(t1, user2);
            Assert.IsTrue(_tournamentManager.TournamentNotPlayed(t1));
        }
    }
}
