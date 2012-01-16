using System;
using Cqrsnes.Infrastructure;

namespace KenoRobot.DomainModel.Events
{
    /// <summary>
    /// Indicates that certain pair appeared in certain drawing.
    /// </summary>
    public class PairAppeared : Event
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
