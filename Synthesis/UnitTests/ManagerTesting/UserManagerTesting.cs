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
    public class UserManagerTesting
    {
        private readonly UserManager _userManager;
        //private readonly TournamentManager _tournamentManager;

        public UserManagerTesting()
        {
            IUserRepository userRepository;
            userRepository = new UserRepositoryMock();
            _userManager = new UserManager(userRepository);
        }

        [TestMethod]
        public void GetUserTest()
        {
            var expected = new Employee(1,"bla", "bla", "bla", "bla", AccountType.Employee, "bla", "bla");
            _userManager.AddUser(expected);
            var actual = _userManager.GetUser(1);
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetNullUserTest()
        {
            var expected = new Employee(1,"bla", "bla", "bla", "bla", AccountType.Employee, "bla", "bla");
            _userManager.AddUser(expected);
            var actual = _userManager.GetUser(2);
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void GetAllUsersTest()
        {
            User user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054",0,0);
            User user2 = new Employee(2, "doll", "en", "bla@g.com", "32434453141", AccountType.Employee, "dona", "6555");

            List<User> expected = new List<User>();
            expected.Add(user1);
            expected.Add(user2);

            _userManager.AddUser(user1);
            _userManager.AddUser(user2);
            List<User> actual = _userManager.GetAllUsers();
            CollectionAssert.AreEqual(expected, actual);
        }

        /*[TestMethod]
        public void GetPlayersWinsPerTournament()
        {
            User user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            //Tournament tournament = new RoundRobin();
        }

        [TestMethod]
        public void GetAllPlayersPerTournament()
        {
            User user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            User user2 = new Player(2, "doll", "en", "bla@g.com", "32434453141", AccountType.Employee, "dona", "6555",0,0);
            List<User> expected = new List<User>();
            expected.Add(user1);
            expected.Add(user2);

            Tournament tournament = new RoundRobin(1, "bla", "bla", "bla", TournamentType.RoundRobin, DateTime.Now,
                DateTime.Now, 2, 10);
            _tournamentManager.AddTournament(tournament);
            _tournamentManager.AddPlayerToTournament(tournament,user1);
            _tournamentManager.AddPlayerToTournament(tournament,user2);
            List<User> actual = _userManager.GetAllPlayersPerTournament(tournament.Id);
            CollectionAssert.AreEqual(expected, actual);
        }*/

        [TestMethod]
        public void AddUserTest()
        {
            var expected = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(expected);
            var actual = _userManager.GetUser(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameUserTest()
        {
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user1);
            var user2 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameUsersUsernameTest()
        {
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user1);
            var user2 = new Player(2, "csd", "dwwed", "ewdwed@g.com", "2132133141", AccountType.Player, "bla", "csdd", 0, 0);
            _userManager.AddUser(user2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddSameUsersPasswordTest()
        {
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user1);
            var user2 = new Player(2, "csd", "dwwed", "ewdwed@g.com", "2132133141", AccountType.Player, "dscdc", "6054", 0, 0);
            _userManager.AddUser(user2);
        }

        [TestMethod]
        public void UpdateUser()
        {
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user1);
            var expected = new Player(1, "dona", "bona", "ssss@g.com", "32434453141", AccountType.Player, "zzz", "6054", 0, 0);
            _userManager.UpdateUser(expected);
            User actual = _userManager.GetUser(1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserNotExist()
        {
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user1);
            var expected = new Player(2, "dona", "bona", "ssss@g.com", "32434453141", AccountType.Player, "zzz", "6054", 0, 0);
            _userManager.UpdateUser(expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserNull()
        {
            User expected = null;
            _userManager.UpdateUser(expected);
        }

        [TestMethod]
        public void UpdateUserPassword()
        {
            string password1 = "2025";
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", password1, 0, 0);
            _userManager.AddUser(user1);
            string expected = "1111";
            var user2 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", password1, 0, 0);
            _userManager.UpdateUserPassword(user2,expected);
            var user = _userManager.GetUser(user2.Id);
            string actual = user.Password;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateUserPasswordWithUsedOne()
        {
            string password1 = "2025";
            var user1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", password1, 0, 0);
            _userManager.AddUser(user1);
            string expected = "2025";
            var user2 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", password1, 0, 0);
            _userManager.UpdateUserPassword(user2, expected);
        }

        [TestMethod]
        public void DeleteUser()
        {
            var user = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(user);
            _userManager.DeleteUser(user.Id);
            Assert.IsNull(_userManager.GetUser(user.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteUserInvalid()
        {
            _userManager.DeleteUser(-1);
        }

        [TestMethod]
        public void UserIsWinner()
        {
            var p1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(p1);
            _userManager.IsWinner(p1);
            User u2 = _userManager.GetUser(1);
            Player p2 = (Player)u2;
            int actual = p2.Wins;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void UserIsLoser()
        {
            var p1 = new Player(1, "bla", "bla", "bla@g.com", "32434453141", AccountType.Player, "bla", "6054", 0, 0);
            _userManager.AddUser(p1);
            _userManager.IsLoser(p1);
            User u2 = _userManager.GetUser(1);
            Player p2 = (Player)u2;
            int actual = p2.Losses;
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
    }
}
