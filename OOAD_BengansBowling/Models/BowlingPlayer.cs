using System;

namespace OOAD_BengansBowling.Models
{
    public class BowlingPlayer
    {
        public Guid Id { get; set; } = new Guid();
        public BowlingParty Party { get; set; }

        public BowlingSet[] BowlingSets { get; set; } = new BowlingSet[3];
    }
}
