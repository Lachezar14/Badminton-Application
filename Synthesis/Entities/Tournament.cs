using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.ENums;

namespace Entities
{
    public abstract class Tournament
    {
        public int Id
        {
            get { return _id;}
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }
        public SportType SportType
        {
            get { return _sportType; }
            private set
            {
                _sportType = value;
            }
        }

        public string Description
        {
            get { return _description;}
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description cannot be empty.");
                }
                _description = value;
            }
        }

        public string Location
        {
            get { return _location; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Location name cannot be empty.");
                }
                _location = value;
            }
        }

        public TournamentType TournamentType
        {
            get { return _tournamentType; }
            private set
            {
                _tournamentType = value;
            }
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            private set
            {
                _startDate = value;
            }
        }

        public DateTime EndDate
        {
            get { return _endDate; }
            private set
            {
                if (value <= _startDate)
                {
                    throw new ArgumentException("End Date of the tournament cannot be before start date.");
                }
                _endDate = value;
            }
        }

        public int MinPlayers
        {
            get { return _minPlayers; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Minimum amount of players cannot be fewer than 2");
                }
                _minPlayers = value;
            }
        }

        public int MaxPlayers
        {
            get { return _maxPlayers; }
            private set
            {
                if (value > 50)
                {
                    throw new ArgumentException("Maximum amount of players cannot be greater than 50");
                }
                if (value < 2)
                {
                    throw new ArgumentException("Maximum amount of players cannot be fewer than 2");
                }
                _maxPlayers = value;
            }
        }

        public List<User> Players
        {
            get { return _players; }
            set
            {
                if (value.Count > _maxPlayers)
                {
                    throw new ArgumentException("Maximum amount of players cannot be greater than maximum players allowed");
                }
                _players = value;
            }
        }
        
        public Tournament(int id, SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers)
        {
            Id = id;
            SportType = sportType;
            Description = description;
            Location = location;
            TournamentType = tournamentType;
            StartDate = startDate;
            EndDate = endDate;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        public Tournament(SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers)
        {
            SportType = sportType;
            Description = description;
            Location = location;
            TournamentType = tournamentType;
            StartDate = startDate;
            EndDate = endDate;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
        }

        public Tournament(int id, SportType sportType, string description, string location, TournamentType tournamentType, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, List<User> players)
        {
            Id = id;
            SportType = sportType;
            Description = description;
            Location = location;
            TournamentType = tournamentType;
            StartDate = startDate;
            EndDate = endDate;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Players = players;
        }

        public abstract List<AMatch> CreateSchedule();

        public override string ToString()
        {
            return $"From {StartDate.ToString("d")} to {EndDate.ToString("d")} | {Description} [{Players.Count}/{MaxPlayers}] players";
        }

        private int _id;
        private SportType _sportType;
        private string _description;
        private string _location;
        private TournamentType _tournamentType;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _minPlayers;
        private int _maxPlayers;
        private List<User> _players = new List<User>();
        
        public override bool Equals(Object obj)
        {
            if (obj is Tournament that)
            {
                return Id == that.Id &&
                       SportType == that.SportType &&
                       Description == that.Description &&
                       Location == that.Location &&
                       TournamentType == that.TournamentType &&
                       StartDate == that.StartDate &&
                       EndDate == that.EndDate &&
                       MinPlayers == that.MinPlayers &&
                       MaxPlayers == that.MaxPlayers &&
                       Players == that.Players;
            }
            return false;
        }

    }
}
