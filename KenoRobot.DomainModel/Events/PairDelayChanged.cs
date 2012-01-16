using System;
using Cqrsnes.Infrastructure;

namespace KenoRobot.DomainModel.Events
{
    /// <summary>
    /// Indicates that delay of certain pair was changed.
    /// </summary>
    public class PairDelayChanged : Event
    {
        /// <summary>
        /// Gets or sets pair id.
        /// </summary>
        public Guid PairId { get; set; }

        /// <summary>
        /// Gets or sets delay.
        /// </summary>
        public int Delay { get; set; }
    }
}
