using System;

namespace OOAD_BengansBowling.Models
{
    public class BowlingParty
    {

        public Guid Id { get; } = new Guid();
        public string Name { get; set; }
        public bool IsMember { get; set; }
    }
}
