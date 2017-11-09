using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOAD_BengansBowling.Models;

namespace OOAD_BengansBowlingTest
{
    [TestClass]
    public class BowlingSetTest
    {
        private BowlingSet _set;

        [TestInitialize]
        public void Initialize()
        {
            _set = new BowlingSet();
        }

        [TestMethod]
        public void CanRollGutterGame()
        {
            RollMany(0,20);
            Assert.AreEqual(0, _set.Score);
        }

        [TestMethod]
        public void CanRollAllOnes()
        {
            RollMany(1, 20);
            Assert.AreEqual(20, _set.Score);
        }

        [TestMethod]
        public void CanRollSpare()
        {
            _set.Roll(5);
            _set.Roll(5);
            _set.Roll(3);
            RollMany(0, 17);
            Assert.AreEqual(16, _set.Score);
        }

        [TestMethod]
        public void CanRollStrike()
        {

            _set.Roll(10);
            _set.Roll(3);
            _set.Roll(4);
            RollMany(0, 16);
            Assert.AreEqual(24, _set.Score);
        }

        [TestMethod]
        public void CanRollPerfectGame()
        {
            RollMany(10, 12);
            Assert.AreEqual(300, _set.Score);
        }

        [TestMethod]
        public void StrikeOnSecondTryCountsAsSpare()
        {
            _set.Roll(0);
            _set.Roll(10);
            _set.Roll(5);
            _set.Roll(4);
            RollMany(0, 16);
            Assert.AreEqual(24, _set.Score);
        }

        private void RollMany(int pins, int rolls)
        {
            for (var i = 0; i < rolls; i++)
                _set.Roll(pins);
        }
    }
}
