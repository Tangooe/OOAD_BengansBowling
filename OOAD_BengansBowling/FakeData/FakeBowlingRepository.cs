using OOAD_BengansBowling.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OOAD_BengansBowling.FakeData
{
    public class FakeBowlingRepository
    {
        private static FakeBowlingRepository _instance;

        private IList<BowlingParty> Parties => new[]
        {
            new BowlingParty
            {
                Name = "Emil Ekman",
                IsMember = true
            },
            new BowlingParty
            {
                Name = "Grognac, The Bowling God",
                IsMember = true
            },
        };

        private IList<BowlingLane> Lanes => new[]
        {
            new BowlingLane
            {
                Id = 1
            },
            new BowlingLane
            {
                Id = 2
            },
            new BowlingLane
            {
                Id = 3
            }
        };

        private IList<BowlingGame> Games => new[]
        {
            new BowlingGame
            {
                Player1 = new BowlingPlayer
                {
                    Party = Parties[0],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11)
                    }
                },
                Player2 = new BowlingPlayer
                {
                    Party = Parties[1],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(4, 20)
                    }
                },
                BowlingLane = Lanes[0],
                IsCompetition = true,
                DateTime = new DateTime(2017, 02, 01, 15, 00, 00)
            },
            new BowlingGame
            {
                Player1 = new BowlingPlayer
                {
                    Party = Parties[0],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(4, 20)
                    }
                },
                Player2 = new BowlingPlayer
                {
                    Party = Parties[1],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11)
                    }
                },
                BowlingLane = Lanes[0],
                IsCompetition = true,
                DateTime = new DateTime(2017, 03, 01, 15, 00, 00)
            },
            new BowlingGame
            {
                Player1 = new BowlingPlayer
                {
                    Party = Parties[0],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11)
                    }
                },
                Player2 = new BowlingPlayer
                {
                    Party = Parties[1],
                    BowlingSets = new[]
                    {
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(10, 11),
                        new BowlingSet().RollMany(4, 20)
                    }
                },
                BowlingLane = Lanes[0],
                                IsCompetition = true,
                DateTime = new DateTime(2017, 04, 01, 15, 00, 00)
            }
        };

        protected FakeBowlingRepository()
        {
        }

        public static FakeBowlingRepository Instance => _instance ?? (_instance = new FakeBowlingRepository());

        public void AddGame(BowlingGame game) => Games.Add(game);

        public void AddParty(BowlingParty party) => Parties.Add(party);

        public IEnumerable<BowlingGame> GetAllGames() => Games;
        public BowlingGame GetGame(Guid id) => Games.FirstOrDefault(g => g.Id == id);

        public IEnumerable<BowlingLane> GetAllLanes() => Lanes;
        public BowlingLane GetLane(int id) => Lanes.FirstOrDefault(l => l.Id == id);
        public BowlingLane GetAvaliableLane() => Lanes.FirstOrDefault(l => l.IsAvaliable);

        public IEnumerable<BowlingParty> GetAllParties() => Parties;
        public BowlingParty GetParty(Guid id) => Parties.FirstOrDefault(p => p.Id == id);
    }
}
