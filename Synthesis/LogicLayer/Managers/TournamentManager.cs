using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Entities;
using DAL.Interfaces;
using Entities.ENums;
using LogicLayer.Interfaces;

namespace LogicLayer.Managers
{
    public class TournamentManager : ITournamentManager
    {
        private ITournamentRepository _tournamentRepository;
        private IMatchRepository _matchRepository;
        private List<Tournament> tournaments;

        public TournamentManager(ITournamentRepository tournamentRepository, IMatchRepository matchRepository)
        {
            this._tournamentRepository = tournamentRepository;
            this._matchRepository = matchRepository;
            tournaments = _tournamentRepository.GetAllTournaments();
        }

        public void ResetAllTournaments()
        {
            tournaments = _tournamentRepository.GetAllTournaments();
        }

        public Tournament GetTournament(int id)
        {
            foreach (Tournament tournament in tournaments)
            {
                if (tournament.Id == id)
                {
                    return tournament;
                }
            }

            return null;
        }


        public List<Tournament> GetAllTournaments()
        {
            return tournaments;
        }

        public List<Tournament> GetAllTournamentsPerPlayer(User user)
        {
            return _tournamentRepository.GetAllTournamentsPerPlayer(user);
        }

        public void CreateSchedule(Tournament tournament)
        {
            foreach (AMatch match in tournament.CreateSchedule())
            {
                if (_matchRepository.GetMatchByPlayersAndTournament(match.Tournament.Id, match.Player1.Id,
                        match.Player2.Id) == null)
                {
                    _matchRepository.AddMatch(match);
                }
            }
        }

        public void AddPlayerToTournament(Tournament tournament, User player)
        {
            if (tournament == null || player == null)
            {
                throw new ArgumentException("Tournament or player is null");
            }

            if (tournament.Players.Find(p => p.Id == player.Id) != null)
            {
                throw new ArgumentException("Player is already in tournament");
            }

            if (tournament.Players.Count == tournament.MaxPlayers)
            {
                throw new ArgumentException("Max Players count has been reached");
            }
            else
            {
                _tournamentRepository.AddPlayerToTournament(tournament, player);

                foreach (Tournament t in tournaments)
                {
                    if (t.Id == tournament.Id)
                    {
                        t.Players.Add(player);
                    }
                }
            }
        }

        public void RemovePlayerFromTournament(Tournament tournament, User player)
        {
            if (tournament == null || player == null)
            {
                throw new ArgumentException("Tournament or player is null");
            }

            if (tournament.Players.Find(p => p.Id == player.Id) == null)
            {
                throw new ArgumentException("Player is not in tournament");
            }
            else
            {
                _tournamentRepository.RemovePlayerFromTournament(tournament, player);

                foreach (Tournament t in tournaments)
                {
                    if (t.Id == tournament.Id)
                    {
                        t.Players.Remove(player);
                    }
                }
            }
        }

        public void AddTournament(Tournament tournament)
        {
            if (tournament == null)
            {
                throw new ArgumentException("Tournament is empty");
            }

            if (tournaments.Find(t => t.Description == tournament.Description) != null)
            {
                throw new ArgumentException("Tournament already exists");
            }
            else
            {
                tournaments.Add(tournament);
                _tournamentRepository.AddTournament(tournament);
            }
        }

        public void UpdateTournament(Tournament tournament)
        {
            if (tournaments.Find(t => t.Id == tournament.Id) == null)
            {
                throw new ArgumentException("Tournament not found");
            }
            else
            {
                _tournamentRepository.UpdateTournament(tournament);
                
                int index = tournaments.FindIndex(t => t.Id == tournament.Id);
                if (index >= 0)
                { 
                    tournaments[index] = tournament;
                }
            }
            
        }

        public void DeleteTournament(int id)
        {
            if (tournaments.Find(t => t.Id == id) == null)
            {
                throw new ArgumentException("Tournament doesn't exist");
            }
            else
            {
                tournaments.Remove(GetTournament(id));
                _tournamentRepository.DeleteTournament(id);
            }

        }

        public bool TournamentLocked(Tournament tournament)
        {
            if (tournaments.Find(t => t.Id == tournament.Id) == null)
            {
                throw new ArgumentException("Tournament not found");
            }
            else
            {
                if ((tournament.StartDate - DateTime.Now).TotalDays < 7 || DateTime.Now >= tournament.StartDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool TournamentNotPlayed(Tournament tournament)
        {
            if ((tournament.StartDate - DateTime.Now).TotalDays < 7 && tournament.Players.Count < tournament.MinPlayers)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
