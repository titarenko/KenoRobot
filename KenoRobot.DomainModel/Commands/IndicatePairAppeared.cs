using System;
using Cqrsnes.Infrastructure;

namespace KenoRobot.DomainModel.Commands
{
    /// <summary>
    /// Specifies to indicate that pair appeared.
    /// </summary>
    public class IndicatePairAppeared : Command
    {
        /// <summary>
        /// Gets or sets pair id.
        /// </summary>
        public Guid PairId { get; set; }

        /// <summary>
        /// Gets or sets drawing number.
        /// </summary>
        public int DrawingNumber { get; set; }
    }
}
