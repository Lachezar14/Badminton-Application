using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ENums;
using Google.Protobuf.Reflection;

namespace Entities
{
    public class DoubleRoundRobin : Tournament
    {
        public DoubleRoundRobin(int id, SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate,
           int minPlayers, int maxPlayers, List<User> players) : base(id, sportType, description, location, tournamentType, startDate, endDate, minPlayers, maxPlayers, players) { }

        public DoubleRoundRobin(int id, SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate,
            int minPlayers, int maxPlayers) : base(id, sportType, description, location, tournamentType, startDate, endDate, minPlayers, maxPlayers) { }

        public DoubleRoundRobin(SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate,
            int minPlayers, int maxPlayers) : base(sportType, description, location, tournamentType, startDate, endDate, minPlayers, maxPlayers) { }

        public override List<AMatch> CreateSchedule()
        {
            int homegames = 0;

            //_scheduleManager.GetSchedule();
            List<User> players = this.Players; //gets the list of players in a tournament
            var matches = new List<AMatch>(); //list to store the matches

            if (players == null || players.Count < this.MinPlayers)
            {
                return matches; //if there are no players or they are less than the min. allowed it just returns empty list
            }

            var restPlayers = new List<User>(players.Skip(1)); //list of players that will be skipped in a round
            var playersCount = players.Count; //gets the number of players
            if (players.Count % 2 != 0)
            {
                restPlayers.Add(default);
                playersCount++;  //if players are odd it adds dummy player to the list of players and whoever plays him skips the round
            }

            for (var round = 0; round < playersCount-1; round++) //loop for every round 
            {
                if (restPlayers[round % restPlayers.Count]?.Equals(default) == false) //if the player is not the dummy player the he plays a match
                {
                    AMatch match = new AMatch(this, players[0], restPlayers[round % restPlayers.Count], 0, 0, round);
                    matches.Add(match);
                }

                for (var index = 1; index < playersCount / 2; index++)
                {
                    var firstPlayer = restPlayers[(round + index) % restPlayers.Count];
                    var secondPlayer = restPlayers[(round + restPlayers.Count - index) % restPlayers.Count];
                    if (firstPlayer?.Equals(default) == false && secondPlayer?.Equals(default) == false)
                    {
                        homegames = round;
                        AMatch match = new AMatch(this, firstPlayer, secondPlayer, 0, 0, round);
                        matches.Add(match);
                    }
                }
            }

            for (var round = homegames + 1; round < (playersCount - 1) * 2; round++) //loop for every round 
            {
                if (restPlayers[round % restPlayers.Count]?.Equals(default) == false) //if the player is not the dummy player the he plays a match
                {
                    AMatch match = new AMatch(this, restPlayers[round % restPlayers.Count],  players[0], 0, 0, round);
                    matches.Add(match);
                }

                for (var index = 1; index < playersCount / 2; index++)
                {
                    var firstPlayer = restPlayers[(round + restPlayers.Count - index) % restPlayers.Count];
                    var secondPlayer =  restPlayers[(round + index) % restPlayers.Count];
                    if (firstPlayer?.Equals(default) == false && secondPlayer?.Equals(default) == false)
                    {
                        AMatch match = new AMatch(this, firstPlayer, secondPlayer, 0, 0, round);
                        matches.Add(match);
                    }
                }
            }

            return matches;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
