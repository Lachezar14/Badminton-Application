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
    public class MatchManagerTesting
    {
        private MatchManager _matchManager;

        public MatchManagerTesting()
        {
            IMatchRepository matchRepository;
            matchRepository = new MatchRepositoryMock();
            _matchManager = new MatchManager(matchRepository);
        }

        [TestMethod]
        public void GetMatch()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1,tournament, player1, player2, 0, 0, 1);
            _matchManager.AddMatch(expected);
            var actual = _matchManager.GetMatch(1);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetAllMatches()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var match1 = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            var match2 = new AMatch(2, tournament, player2, player1, 0, 0, 2);
            List<AMatch> expected = new List<AMatch>();
            expected.Add(match1);
            expected.Add(match2);
            _matchManager.AddMatch(match1);
            _matchManager.AddMatch(match2);
            List<AMatch> actual = _matchManager.GetAllMatches();
            CollectionAssert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AddMatch()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var expected = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            _matchManager.AddMatch(expected);
            var actual = _matchManager.GetMatch(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullMatch()
        {
            AMatch match = null;
            _matchManager.AddMatch(match);

        }

        [TestMethod]
        public void UpdateMatch()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var match1 = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            _matchManager.AddMatch(match1);
            var expected = new AMatch(1, tournament, player1, player2, 18, 21, 1);
            _matchManager.UpdateMatch(expected);
            var actual = _matchManager.GetMatch(1);
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateNullMatch()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var match1 = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            _matchManager.AddMatch(match1);
            AMatch expected = null;
            _matchManager.UpdateMatch(expected);
        }

        [TestMethod]
        public void DeleteMatch()
        {
            var tournament = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10);
            var player1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            var player2 = new Player(2, "blacsa", "blaca", "bla@g.com", "32434453141", AccountType.Player, "blacsa", "3054", 0, 0);
            var match1 = new AMatch(1, tournament, player1, player2, 0, 0, 1);
            _matchManager.AddMatch(match1);
            _matchManager.DeleteMatch(1);
            Assert.IsNull(_matchManager.GetMatch(1));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteNullMatch()
        {
            _matchManager.DeleteMatch(1);
        }
    }
}
