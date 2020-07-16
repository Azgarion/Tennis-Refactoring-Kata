using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace Tennis
{
    class TennisGame1 : ITennisGame
    {
        private Score m_score1 = new Score();
        private Score m_score2 = new Score();
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
            {
                if (m_score1 == Point.Forty)
                {
                    if(m_score2 < Point.Forty || m_score1.IsAdvantage())
                    {
                        m_score1.SetVictory();
                        Console.WriteLine(playerName + " won point and so is victorious.");
                    }
                    else
                    {
                        m_score1.SetAdvantage();
                        Console.WriteLine(playerName + " won point and take advantage.");
                        m_score2.WithdrawAdvantage();
                    }
                }
                else
                {
                    m_score1.AddPoint();
                    Console.WriteLine(playerName + " won point. Increment score. Score : " + m_score1);
                }

            }
            else
            {
                if (m_score2 == Point.Forty)
                {
                    if(m_score1 < Point.Forty || m_score2.IsAdvantage())
                    {
                        m_score2.SetVictory();
                        Console.WriteLine(playerName + " won point and so is victorious.");

                    }
                    else
                    {
                        m_score2.SetAdvantage();
                        Console.WriteLine(playerName + " won point and take advantage.");
                        m_score1.WithdrawAdvantage();
                    }
                }
                else
                {
                    m_score2.AddPoint();
                    Console.WriteLine(playerName + " won point. Increment score. Score : " + m_score2);
                }

            }
        }

        public string GetScore()
        {
            string score = "";
            if (m_score1.IsVictory()) score = "Win for player1";
            else if (m_score2.IsVictory()) score = "Win for player2";
            else if (m_score1.IsAdvantage()) score = "Advantage player1";
            else if (m_score2.IsAdvantage()) score = "Advantage player2";
            else if (m_score1 == m_score2)
            {
                score = m_score1 + "-All";
                
                if (m_score1 == Point.Forty)
                {
                    score = "Deuce";
                }
            }
            else score = m_score1.Point + "-" + m_score2.Point;
            
            Console.WriteLine(score);
            return score;
        }
    }

    internal class Score
    {
        public Point Point { get; private set; }

        private bool _advantage;
        private bool _victory;

        public Score()
        {
            Point = Point.Love;
        }

        public void AddPoint()
        {
            this.Point += 1;
        }

        public bool IsAdvantage()
        {
            return _advantage;
        }

        public void SetAdvantage()
        {
            this._advantage = true;
        }
        
        public void WithdrawAdvantage()
        {
            this._advantage = false;
        }
        
        public bool IsVictory()
        {
            return _victory;
        }

        public void SetVictory()
        {
            this._victory = true;
        }
        
        public static bool operator ==(Score score1, Score score2)
        {
            return score1?.Point == score2?.Point;
        } 
        
        public static bool operator !=(Score score1, Score score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            if (score2 == null) throw new ArgumentNullException(nameof(score2));
            return score1.Point != score2.Point;
        }
        
        public static bool operator ==(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return score1.Point == score2;
        } 
        
        public static bool operator !=(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return score1.Point != score2;
        }
        
        public static bool operator >=(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return (int)score1.Point >= (int)score2;
        }
        
        public static bool operator <=(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return (int)score1.Point <= (int)score2;
        }
        
        public static bool operator >(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return (int)score1.Point > (int)score2;
        }
        
        public static bool operator <(Score score1, Point score2)
        {
            if (score1 == null) throw new ArgumentNullException(nameof(score1));
            return (int)score1.Point < (int)score2;
        }

        public override string ToString() => this.Point.ToString();
    }

    public enum Point
    {
        Love = 0,
        Fifteen = 1,
        Thirty = 2,
        Forty = 3,
        Advantage = 4,
        Win = 5
    }
}

