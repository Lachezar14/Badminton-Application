using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using Entities.ENums;
using LogicLayer.Managers;
using LogicLayer.Utilities;
using UnitTests.MockRepositories;

namespace UnitTests.ManagerTesting
{
    [TestClass]
    public class AuthenticationManagerTesting
    {
        private AuthenticationManager _authenticationManager;
        private UserManager _userManager;
        private PasswordHasher _passwordHasher = new PasswordHasher();

        public AuthenticationManagerTesting()
        {
            IUserRepository userRepository;
            userRepository = new UserRepositoryMock();
            _userManager = new UserManager(userRepository);
            _authenticationManager = new AuthenticationManager(userRepository,_userManager);
        }

        [TestMethod]
        public void GetPlayerByUsername()
        {
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla","bla",0,0);
            User p2 = new Player(2, "blaasc", "bacla", "bcala","bacla", AccountType.Player,"blascaa","blasaca",0,0);
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea","blaee");
            _userManager.AddUser(p1);
            _userManager.AddUser(p2);
            _userManager.AddUser(e1);
            var expected = p1;
            User actual = _authenticationManager.GetPlayerByUsername("bla");
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetNullPlayerByUsername()
        {
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla","bla",0,0);
            User p2 = new Player(2, "blaasc", "bacla", "bcala","bacla", AccountType.Player,"blascaa","blasaca",0,0);
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea","blaee");
            _userManager.AddUser(p1);
            _userManager.AddUser(p2);
            _userManager.AddUser(e1);
            var expected = p1;
            User actual = _authenticationManager.GetPlayerByUsername("dadaa");
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetEmployeeByUsername()
        {
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla","bla",0,0);
            User p2 = new Player(2, "blaasc", "bacla", "bcala","bacla", AccountType.Player,"blascaa","blasaca",0,0);
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea","blaee");
            _userManager.AddUser(p1);
            _userManager.AddUser(p2);
            _userManager.AddUser(e1);
            var expected = e1;
            User actual = _authenticationManager.GetEmployeeByUsername("bleea");
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void GetNullEmployeeByUsername()
        {
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla","bla",0,0);
            User p2 = new Player(2, "blaasc", "bacla", "bcala","bacla", AccountType.Player,"blascaa","blasaca",0,0);
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea","blaee");
            _userManager.AddUser(p1);
            _userManager.AddUser(p2);
            _userManager.AddUser(e1);
            var expected = e1;
            User actual = _authenticationManager.GetEmployeeByUsername("dadaa");
            Assert.IsNull(actual);
        }
        
        [TestMethod]
        public void AuthenticatePlayer()
        {
            var password = _passwordHasher.HashPassword("bla");
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla",password,0,0);
            _userManager.AddUser(p1);
            int actual = _authenticationManager.AuthenticatePlayer("bla", "bla");
            int expected = 1;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FalseAuthenticatePlayer()
        {
            var password = _passwordHasher.HashPassword("bla");
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla",password,0,0);
            _userManager.AddUser(p1);
            int actual = _authenticationManager.AuthenticatePlayer("bla", "dadaa");
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AuthenticateNullPlayer()
        {
            var password = _passwordHasher.HashPassword("bla");
            User p1 = new Player(1, "bla", "bla", "bla","bla", AccountType.Player,"bla",password,0,0);
            _userManager.AddUser(p1);
            int actual = _authenticationManager.AuthenticatePlayer("dadaaa", "bla");
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AuthenticateEmployee()
        {
            var password = _passwordHasher.HashPassword("blaee");
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea",password);
            _userManager.AddUser(e1);
            int actual = _authenticationManager.AuthenticateEmployee("bleea", "blaee");
            int expected = 3;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void FalseAuthenticateEmployee()
        {
            var password = _passwordHasher.HashPassword("blaee");
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea",password);
            _userManager.AddUser(e1);
            int actual = _authenticationManager.AuthenticateEmployee("bleea", "deddd");
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }
        
        [TestMethod]
        public void AuthenticateNullEmployee()
        {
            var password = _passwordHasher.HashPassword("blaee");
            User e1 = new Employee(3, "beela", "beela", "beela","bleea", AccountType.Employee,"bleea",password);
            _userManager.AddUser(e1);
            int actual = _authenticationManager.AuthenticateEmployee("deeded", "blaee");
            int expected = -1;
            Assert.AreEqual(expected, actual);
        }
        
    }
}
