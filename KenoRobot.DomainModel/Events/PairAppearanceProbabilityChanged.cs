using System;
using Cqrsnes.Infrastructure;

namespace KenoRobot.DomainModel.Events
{
    /// <summary>
    /// States that probability of pair appearance was changed.
    /// </summary>
    public class PairAppearanceProbabilityChanged : Event
    {
        /// <summary>
        /// Gets or sets pair id.
        /// </summary>
        public Guid PairId { get; set; }

        /// <summary>
        /// Gets or sets probability.
        /// </summary>
        public double Probability { get; set; }
    }
}
