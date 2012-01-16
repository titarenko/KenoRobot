using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Commands
{
    /// <summary>
    /// Specifies to add drawing.
    /// </summary>
    public class AddDrawing : Command
    {
        /// <summary>
        /// Gets or sets drawing.
        /// </summary>
        public Drawing Drawing { get; set; }
    }
}
