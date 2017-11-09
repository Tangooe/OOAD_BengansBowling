using System;
using System.Linq;

namespace OOAD_BengansBowling.Models
{
    public class BowlingGame
    {
        public Guid Id { get; set; } = new Guid();
        public BowlingPlayer Player1 { get; set; }
        public BowlingPlayer Player2 { get; set; }
        public BowlingLane BowlingLane { get; set; }
        public bool IsCompetition { get; set; }

        public DateTime DateTime { get; set; }
        
        public BowlingPlayer Winner
        {
            get
            {
                var player1Score = Player1.BowlingSets.Sum(bs => bs.Score);
                var player2Score = Player2.BowlingSets.Sum(bs => bs.Score);

                return player1Score > player2Score ? Player1 : Player2;
            }
        }
    }
}
