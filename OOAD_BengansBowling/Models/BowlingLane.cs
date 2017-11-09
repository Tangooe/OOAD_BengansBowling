namespace OOAD_BengansBowling.Models
{
    public class BowlingLane
    {
        public int Id { get; set; }
        public BowlingGame CurrentGame { get; set; }

        public bool IsAvaliable => CurrentGame.Equals(null);
    }
}
