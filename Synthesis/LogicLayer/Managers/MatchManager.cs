using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL.Interfaces;
using Entities;
using LogicLayer.Interfaces;

namespace LogicLayer.Managers
{
    public class MatchManager : IMatchManager
    {
        private IMatchRepository _matchRepository;
        private List<AMatch> matches;

        public MatchManager(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
            matches = _matchRepository.GetAllMatches();
        }

        public AMatch GetMatch(int id)
        {
            foreach (AMatch match in matches)
            {
                if (match.Id == id)
                {
                    return match;
                }
            }
            return null;
        }

        public AMatch GetMatchByPlayersAndTournament(int tournamentId, int player1Id, int player2Id)
        {
            return _matchRepository.GetMatchByPlayersAndTournament(tournamentId, player1Id, player2Id);
        }

        public List<AMatch> GetAllMatches()
        {
            return matches;
        }

        public List<AMatch> GetAllMatchesPerTournament(Tournament tournament)
        {
            return _matchRepository.GetAllMatchesPerTournament(tournament);
        }

        public void AddMatch(AMatch match)
        {
            if (match == null)
            {
                throw new ArgumentException("Match is null");
            }
            if (GetMatchByPlayersAndTournament(match.Tournament.Id, match.Player1.Id, match.Player2.Id) == null)
            {
                matches.Add(match);
                _matchRepository.AddMatch(match);
            }

        }

        /*public void AddResult(AMatch match,int player1_Score,int player2_Score)
        {
            match.Player1_Score = player1_Score;
            match.Player2_Score = player2_Score;
        }*/

        public void UpdateMatch(AMatch match)
        {
            if (match == null)
            {
                throw new ArgumentException("Match is null");
            }
            else
            {
                _matchRepository.UpdateMatch(match);

                int index = matches.FindIndex(u => u.Id == match.Id);
                if (index >= 0)
                {
                    matches[index] = match;
                }
            }
        }

        public void DeleteMatch(int id)
        {
            if (matches.Find(u => u.Id == id) == null)
            {
                throw new ArgumentException("Match not found");
            }
            else
            {
                matches.Remove(GetMatch(id));
                _matchRepository.DeleteMatch(id);
            }
        }
    }
}
