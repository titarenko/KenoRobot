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
            return 1.0 - Math.Pow(1.0 - 19.0 / 316.0, delay + 1);
        }
    }
}
