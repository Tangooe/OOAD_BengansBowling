using Microsoft.VisualStudio.TestTools.UnitTesting;
using OOAD_BengansBowling.FakeData;
using System.Linq;

namespace OOAD_BengansBowlingTest
{
    [TestClass]
    public class BowlingGameTest
    {
        private static FakeBowlingRepository _repo;

        [TestInitialize]
        public void Initialize()
        {
            _repo = FakeBowlingRepository.Instance;
        }

        [TestMethod]
        public void CanCalculateWinner()
        {
            Assert.AreSame(_repo.GetAllGames().First().Winner, _repo.GetAllGames().First().Player1);
        }
    }
}
