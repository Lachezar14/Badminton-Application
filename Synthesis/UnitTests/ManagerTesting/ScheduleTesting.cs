using DAL.Interfaces;
using Entities;
using Entities.ENums;
using LogicLayer.Managers;
using UnitTests.MockRepositories;

namespace UnitTests.ManagerTesting;

[TestClass]
public class ScheduleTesting
{
    private TournamentManager _tournamentManager;
    private MatchManager _matchManager;
    
    public ScheduleTesting()
    {
        ITournamentRepository tournamentRepository;
        IMatchRepository matchRepository;
        tournamentRepository = new TournamentRepositoryMock();
        matchRepository = new MatchRepositoryMock();
        _tournamentManager = new TournamentManager(tournamentRepository,matchRepository);
        _matchManager = new MatchManager(matchRepository);
    }

    public List<AMatch> RoundRobinMock()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        AMatch m1 = new AMatch(t1,p1,p2,0,0,0);
        AMatch m2 = new AMatch(t1,p3,p4,0,0,0);
        AMatch m3 = new AMatch(t1,p1,p3,0,0,1);
        AMatch m4 = new AMatch(t1,p4,p2,0,0,1);
        AMatch m5 = new AMatch(t1,p1,p4,0,0,2);
        AMatch m6 = new AMatch(t1,p2,p3,0,0,2);
        List<AMatch> matches = new List<AMatch>();
        matches.Add(m1);
        matches.Add(m2);
        matches.Add(m3);
        matches.Add(m4);
        matches.Add(m5);
        matches.Add(m6);
        return matches;
    }
    
    public List<AMatch> OddRoundRobinMock()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        User p5 = new Player(5,"q","q","p5","p5",AccountType.Player,"p5","p5",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        players.Add(p5);
        var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        AMatch m1 = new AMatch(t1,p1,p2,0,0,0);
        AMatch m2 = new AMatch(t1,p4,p5,0,0,0);
        AMatch m3 = new AMatch(t1,p1,p3,0,0,1);
        AMatch m4 = new AMatch(t1,p4,p2,0,0,1);
        AMatch m5 = new AMatch(t1,p1,p4,0,0,2);
        AMatch m6 = new AMatch(t1,p5,p3,0,0,2);
        AMatch m7 = new AMatch(t1,p1,p5,0,0,3);
        AMatch m8 = new AMatch(t1,p2,p3,0,0,3);
        AMatch m9 = new AMatch(t1,p2,p5,0,0,4);
        AMatch m10 = new AMatch(t1,p3,p4,0,0,4);
        List<AMatch> matches = new List<AMatch>();
        matches.Add(m1);
        matches.Add(m2);
        matches.Add(m3);
        matches.Add(m4);
        matches.Add(m5);
        matches.Add(m6);
        matches.Add(m7);
        matches.Add(m8);
        matches.Add(m9);
        matches.Add(m10);
        return matches;
    }
    
    public List<AMatch> DoubleRoundRobinMock()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        var t1 = new DoubleRoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.DoubleRoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        AMatch m1 = new AMatch(t1,p1,p2,0,0,0);
        AMatch m2 = new AMatch(t1,p3,p4,0,0,0);
        AMatch m3 = new AMatch(t1,p1,p3,0,0,1);
        AMatch m4 = new AMatch(t1,p4,p2,0,0,1);
        AMatch m5 = new AMatch(t1,p1,p4,0,0,2);
        AMatch m6 = new AMatch(t1,p2,p3,0,0,2);
        AMatch m7 = new AMatch(t1,p2,p1,0,0,3);
        AMatch m8 = new AMatch(t1,p4,p3,0,0,3);
        AMatch m9 = new AMatch(t1,p3,p1,0,0,4);
        AMatch m10 = new AMatch(t1,p2,p4,0,0,4);
        AMatch m11 = new AMatch(t1,p4,p1,0,0,5);
        AMatch m12 = new AMatch(t1,p3,p2,0,0,5);
        List<AMatch> matches = new List<AMatch>();
        matches.Add(m1);
        matches.Add(m2);
        matches.Add(m3);
        matches.Add(m4);
        matches.Add(m5);
        matches.Add(m6);
        matches.Add(m7);
        matches.Add(m8);
        matches.Add(m9);
        matches.Add(m10);
        matches.Add(m11);
        matches.Add(m12);
        return matches;
    }
    
    public List<AMatch> OddDoubleRoundRobinMock()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        var t1 = new DoubleRoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.DoubleRoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        AMatch m1 = new AMatch(t1,p1,p2,0,0,0);
        AMatch m2 = new AMatch(t1,p1,p3,0,0,1);
        AMatch m3 = new AMatch(t1,p2,p3,0,0,2);
        AMatch m4 = new AMatch(t1,p2,p1,0,0,3);
        AMatch m5 = new AMatch(t1,p3,p1,0,0,4);
        AMatch m6 = new AMatch(t1,p3,p2,0,0,5);
        List<AMatch> matches = new List<AMatch>();
        matches.Add(m1);
        matches.Add(m2);
        matches.Add(m3);
        matches.Add(m4);
        matches.Add(m5);
        matches.Add(m6);
        return matches;
    }

    [TestMethod]
    public void CreateRoundRobinSchedule()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        List<AMatch> actual = t1.CreateSchedule();
        List<AMatch> expected = RoundRobinMock();
        CollectionAssert.AreEqual(expected,actual);
    }
    
    [TestMethod]
    public void CreateOddRoundRobinSchedule()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        User p5 = new Player(5,"q","q","p5","p5",AccountType.Player,"p5","p5",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        players.Add(p5);
        var t1 = new RoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.RoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        List<AMatch> actual = t1.CreateSchedule();
        List<AMatch> expected = OddRoundRobinMock();
        CollectionAssert.AreEqual(expected,actual);
    }
    
    [TestMethod]
    public void CreateDoubleRoundRobinSchedule()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        User p4 = new Player(4,"o","o","p4","p4",AccountType.Player,"p4","p4",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        players.Add(p4);
        var t1 = new DoubleRoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.DoubleRoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        List<AMatch> actual = t1.CreateSchedule();
        List<AMatch> expected = DoubleRoundRobinMock();
        CollectionAssert.AreEqual(expected,actual);
        // for (int i = 0; i < actual.Count; i++)
        // {
        //     Assert.IsTrue(actual[i].Equals(expected[i]));
        // }
    }
    
    [TestMethod]
    public void CreateOddDoubleRoundRobinSchedule()
    {
        User p1 = new Player(1,"p","p","p1","p1",AccountType.Player,"p1","p1",0,0);
        User p2 = new Player(2,"l","l","p2","p2",AccountType.Player,"p2","p2",0,0);
        User p3 = new Player(3,"m","m","p3","p3",AccountType.Player,"p3","p3",0,0);
        List<User> players = new List<User>();
        players.Add(p1);
        players.Add(p2);
        players.Add(p3);
        var t1 = new DoubleRoundRobin(1, SportType.Badminton, "bla", "bla", TournamentType.DoubleRoundRobin, DateTime.Now, DateTime.Now, 2, 10,players);
        List<AMatch> actual = t1.CreateSchedule();
        List<AMatch> expected = OddDoubleRoundRobinMock();
       CollectionAssert.AreEqual(expected,actual);
       // for (int i = 0; i < actual.Count; i++)
       // {
       //     Assert.IsTrue(actual[i].Equals(expected[i]));
       // }
    }
}