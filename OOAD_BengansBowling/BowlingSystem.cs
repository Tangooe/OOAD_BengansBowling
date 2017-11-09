using System;
using OOAD_BengansBowling.FakeData;
using System.Linq;
using OOAD_BengansBowling.Models;

namespace OOAD_BengansBowling
{
    public class BowlingSystem
    {
        private readonly FakeBowlingRepository _repo;
        public BowlingSystem()
        {
            _repo = FakeBowlingRepository.Instance;
        }

        public BowlingPlayer GetChampion(int year)
        {
            var winners = _repo.GetAllGames().Where(g => g.DateTime.Year == year).Select(g => g.Winner);
            return winners.GroupBy(w => w).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First();
        }

        public BowlingPlayer GetGameWinner(Guid gameId)
        {
            return _repo.GetGame(gameId)?.Winner;
        }

        public void RegisterNewMember(string name, bool isMember)
        {
            _repo.AddParty(new BowlingParty
            {
                Name = name,
                IsMember = isMember
            });
        }

        public BowlingGame StartNewGame(string player1Name, string player2Name)
        {
            var player1 = _repo.GetAllParties().FirstOrDefault(p => string.Equals(p.Name, player1Name)) ?? new BowlingParty
            {
                Name = player1Name
            };

            var player2 = _repo.GetAllParties().FirstOrDefault(p => string.Equals(p.Name, player1Name)) ?? new BowlingParty
            {
                Name = player1Name
            };

            var lane = _repo.GetAvaliableLane() ?? 
                _repo.GetAllLanes().OrderBy(l => Math.Abs((l.CurrentGame.DateTime - DateTime.Now).Ticks)).First();

            var game = new BowlingGame
            {
                BowlingLane = lane,
                DateTime = DateTime.Now,
                Player1 = new BowlingPlayer
                {
                    Party = player1,
                    BowlingSets = new BowlingSet[3]
                },
                Player2 = new BowlingPlayer
                {
                    Party = player2,
                    BowlingSets = new BowlingSet[3]
                }
            };

            _repo.AddGame(game);

            return game;
        }

        public void WrapUpGame(Guid gameId)
        {
            var game = _repo.GetAllGames().First(g => g.Id == gameId);
            game.BowlingLane.CurrentGame = null;
            var winner = game.Winner;
        }
    }
}
