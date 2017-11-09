namespace OOAD_BengansBowling.Models
{
    public class BowlingSet
    {
        private readonly int[] _rolls = new int[21];
        private int _currentRoll;

        public int Score
        {
            get
            {
                var score = 0;
                var rollIndex = 0;
                for (var frame = 0; frame < 10; frame++)
                {
                    if (IsStrike(rollIndex))
                    {
                        score += GetSpecialScore(rollIndex);
                        rollIndex++;
                        continue;
                    }

                    if (IsSpare(rollIndex))
                        score += GetSpecialScore(rollIndex);
                    else
                        score += GetStandardScore(rollIndex);

                    rollIndex += 2;
                }

                return score;
            }
        }

        public void Roll(int pins) => _rolls[_currentRoll++] = pins;

        private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;

        private bool IsSpare(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] == 10;

        private int GetStandardScore(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1];

        private int GetSpecialScore(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1] + _rolls[rollIndex + 2];

        public BowlingSet RollMany(int pins, int rolls)
        {
            for (var i = 0; i < rolls; i++)
                Roll(pins);

            return this;
        }
    }
}
