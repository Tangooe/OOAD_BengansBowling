using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOAD_BengansBowling.Data;
using OOAD_BengansBowling.Models;
using System.Collections.Generic;

namespace OOAD_BengansBowlingTest
{
    [TestClass]
    public class BowlingDataTest
    {
        private BowlingData _bowlingData;
        private BowlingPlayer _player1;
        private BowlingPlayer _player2;

        [TestInitialize]
        public void Initialize()
        {
            _player1 = new BowlingPlayer("Emil Ekman");
            _player2 = new BowlingPlayer("Grognac The Bowling God");

            var lane1 = new BowlingLane {Id = 1};

            _bowlingData = new BowlingData(new List<BowlingGame>
            {
                SimulateBowlingGame(_player1, _player2, lane1),
                SimulateBowlingGame(_player2, _player1, lane1),
                SimulateBowlingGame(_player1, _player2, lane1),
            });
        }

        [TestMethod]
        public void CanCalculateChampion()
        {
            Assert.AreSame(_bowlingData.GetChampion(2017), _player1);
        }

        private static BowlingGame SimulateBowlingGame(BowlingPlayer winner, BowlingPlayer loser, BowlingLane lane)
        {
            var game = new BowlingGame(winner, loser, lane);
            for (var i = 0; i < 3; i++)
            {
                game.Player1.BowlingSets[i] = RollMany(new BowlingSet(), 4, 20);
                game.Player2.BowlingSets[i] = RollMany(new BowlingSet(), 1, 20);
            }

            return game;
        }

        private static BowlingSet RollMany(BowlingSet set, int pins, int rolls)
        {
            for (var i = 0; i < rolls; i++)
                set.Roll(pins);

            return set;
        }
    }
}
