using System;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Implementation of IPairAppearanceProbabilityCalculator.
    /// </summary>
    public class PairAppearanceProbabilityCalculator : IPairAppearanceProbabilityCalculator
    {
        /// <summary>
        /// Returns probability of appearance for pair with given delay.
        /// </summary>
        /// <param name="delay">Delay.</param>
        /// <returns>Probability.</returns>
        public double GetAppearanceProbability(int delay)
        {
            if (delay < 0)
            {
                throw new ArgumentOutOfRangeException(
                    "delay", "Delay should not be less than 0.");
            }

            return 1.0 - Math.Pow(1.0 - 19.0 / 316.0, delay + 1);
        }
    }
}
