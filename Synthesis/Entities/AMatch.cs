using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AMatch
    {
        public int Id
        {
            get { return _id; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0");
                }
                _id = value;
            }
        }
        public Tournament Tournament => _tournament;
        public User Player1 => _player1;
        public User Player2 => _player2;

        public int Player1_Score
        {
            get { return _player1_Score;}
            private set
            {
                _player1_Score = value;
            }
        }

        public int Player2_Score
        {
            get { return _player2_Score; }
            private set
            {
                _player2_Score = value;
            }
        }
        public int Round 
        { 
            get { return _round; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Round cannot be negative");
                }
                _round = value;
            }
        }

        public AMatch(int id, Tournament tournament, User player1, User player2, int player1_Score, int player2_Score, int round)
        {
            Id = id;
            this._tournament = tournament;
            this._player1 = player1;
            this._player2 = player2;
            _player1_Score = player1_Score;
            _player2_Score = player2_Score;
            Player1_Score = player1_Score;
            Player2_Score = player2_Score;
            Round = round;
        }

        public AMatch(Tournament tournament, User player1, User player2, int player1_Score, int player2_Score, int round)
        {
            
            this._tournament = tournament;
            this._player1 = player1;
            this._player2 = player2;
            _player1_Score = player1_Score;
            _player2_Score = player2_Score;
            Player1_Score = player1_Score;
            Player2_Score = player2_Score;
            Round = round;

        }

        public void Result(int player1Score, int player2Score)
        {
            if (player1Score > player2Score)
            {
                if (player2Score >= 21)
                {
                    if (player1Score - player2Score > 2) 
                    { 
                        throw new ArgumentException("When over 21, winner's score cannot be bigger than 2 point to the loser's.");
                    }
                }
                if (player1Score < 0)
                {
                    throw new ArgumentException("Player 1 score cannot be negative");
                }

                if (player1Score > 30)
                {
                    throw new ArgumentException("Invalid Player 1 score");
                }
                if (player1Score - player2Score < 2)
                {
                    throw new ArgumentException("Winner's score must be at least 2 point more than loser's");
                }

                if (player1Score < 21)
                {
                    throw new ArgumentException("Winner must have at least 21 points.");
                }

                _player1_Score = player1Score;
                _player2_Score = player2Score;
            }
            else if (player2Score > player1Score)
            {
                if (player1Score >= 21)
                {
                    if (player2Score - player1Score > 2) 
                    { 
                        throw new ArgumentException("When over 21, winner's score cannot be bigger than 2 point to the loser's.");
                    }
                }
                if (player2Score < 0)
                {
                    throw new ArgumentException("Player 2 score cannot be negative");
                }

                if (player2Score > 30)
                {
                    throw new ArgumentException("Invalid Player 2 score");
                }
                if (player2Score - player1Score < 2)
                {
                    throw new ArgumentException("Winner's score must be at least 2 point more than loser's");
                }

                if (player2Score < 21)
                {
                    throw new ArgumentException("Winner must have at least 21 points.");
                }

                _player1_Score = player1Score;
                _player2_Score = player2Score;
            }
        }

        public override string ToString()
        {
            if (Player1_Score == 0 && Player2_Score == 0)
            {
                return $"Round{Round} | {Player1.ToString()} vs {Player2.ToString()} (to be played)";
            }
            else
            {
                return $"Round{Round} | {Player1.ToString()} vs {Player2.ToString()} ({Player1_Score} - {Player2_Score})";
            }
        }

        private int _id;
        private User _player1;
        private User _player2;
        private Tournament _tournament;
        private int _player1_Score;
        private int _player2_Score;
        private int _round;
        
        public override bool Equals(Object obj)
        {
            if(obj is not AMatch)
            {
                return false;
            }
            if(this._player1 == _player1 && this._player2 == _player2 && this._tournament == _tournament && this._round == _round && this._player1_Score == _player1_Score && this._player2_Score == _player2_Score)
            {
                return true;
            }
            
            return false;
        }
    }
}
