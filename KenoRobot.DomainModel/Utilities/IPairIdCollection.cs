using System;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Contains collection of identifiers for pairs.
    /// </summary>
    public interface IPairIdCollection
    {
        /// <summary>
        /// Returns identifier for given pair of balls.
        /// </summary>
        /// <param name="ball1">
        /// The ball 1.
        /// </param>
        /// <param name="ball2">
        /// The ball 2.
        /// </param>
        /// <returns>
        /// Identifier for given pair.
        /// </returns>
        Guid GetId(byte ball1, byte ball2);
    }
}
