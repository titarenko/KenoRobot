using System;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Contains collection of identifiers for pairs.
    /// </summary>
    public interface IPairIdCollection
    {
        /// <summary>
        /// Accesses identifier for given pair.
        /// </summary>
        /// <param name="pair">
        /// The pair to get identifier for.
        /// </param>
        /// <returns>
        /// Identifier for given pair.
        /// </returns>
        Guid this[Pair pair] { get; }
    }
}