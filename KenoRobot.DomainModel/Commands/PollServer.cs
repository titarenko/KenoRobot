using System;
using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Utilities;

namespace KenoRobot.DomainModel.Commands
{
    /// <summary>
    /// Specifies to poll the server.
    /// </summary>
    public class PollServer : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PollServer"/> class.
        /// </summary>
        public PollServer()
        {
            Date = Clock.Now;
        }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime Date { get; set; }
    }
}
