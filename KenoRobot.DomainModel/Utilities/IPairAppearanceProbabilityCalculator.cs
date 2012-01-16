namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Calculates probability of pair appearance.
    /// </summary>
    public interface IPairAppearanceProbabilityCalculator
    {
        /// <summary>
        /// Returns probability of appearance for pair with given delay.
        /// </summary>
        /// <param name="delay">Delay.</param>
        /// <returns>Probability.</returns>
        double GetAppearanceProbability(int delay);
    }
}
