using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Entities.ENums;
using Org.BouncyCastle.Crypto.Digests;

namespace UnitTests.EntitiesTesting
{
    [TestClass]
    public class UserTesting
    {
        [TestMethod]
        public void GetUserId()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            int actual = user.Id;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserFirstName()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.FName;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserLastName()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.LName;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserEmail()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.Email;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserPhoneNumber()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.Phone;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserType()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.Type.ToString();
            string expected = AccountType.Employee.ToString();
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserUsername()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.Username;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void GetUserPassword()
        {
            User user = new User(1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
            string actual = user.Password;
            string expected = "bla";
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongIdUser()
        {
            User user = new User(-1, "bla", "bla", "bla","bla", AccountType.Employee,"bla","bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongFirstNameUser()
        {
            User user = new User(1, "2331", "bla", "bla", "bla", AccountType.Employee, "bla", "bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullFirstNameUser()
        {
            User user = new User(1, null, "bla", "bla", "bla", AccountType.Employee, "bla", "bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddWrongLastNameUser()
        {
            User user = new User(1, "bla", "2331", "bla", "bla", AccountType.Employee, "bla", "bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullLastNameUser()
        {
            User user = new User(1, "bla", null, "bla", "bla", AccountType.Employee, "bla", "bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullUsernameUser()
        {
            User user = new User(1, "bla", "bla", "bla", "bla",AccountType.Employee , null, "bla");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddNullPasswordUser()
        {
            User user = new User(1, "bla", "bla", "bla", "bla", AccountType.Employee,  "bla", null);
        }

        [TestMethod]
        public void AddWinToPlayer()
        {
            Player player = new Player(1, "bla", "bla", "bla", "bla", AccountType.Employee, "bla", "bla", 0, 0);
            player.IsWinner();
            int actual = player.Wins;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void AddLossToPlayer()
        {
            Player player = new Player(1, "bla", "bla", "bla", "bla", AccountType.Employee, "bla", "bla", 0, 0);
            player.IsLoser();
            int actual = player.Losses;
            int expected = 1;
            Assert.AreEqual(expected,actual);
        }
    }
}
