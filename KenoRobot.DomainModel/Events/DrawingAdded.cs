using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Events
{
    /// <summary>
    /// Indicates that certain drawing was added.
    /// </summary>
    public class DrawingAdded : Event
    {
        /// <summary>
        /// Gets or sets drawing.
        /// </summary>
        public Drawing Drawing { get; set; }
    }
}
