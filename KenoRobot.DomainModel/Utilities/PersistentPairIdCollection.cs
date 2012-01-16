using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Contains collection of identifiers for pairs.
    /// </summary>
    public class PersistentPairIdCollection : IPairIdCollection
    {
        private const string FILENAME = "ids.bin";

        private readonly Guid[] ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistentPairIdCollection"/> class.
        /// </summary>
        public PersistentPairIdCollection()
        {
            try
            {
                using (var stream = new FileStream(FILENAME, FileMode.Open))
                {
                    ids = (Guid[]) new BinaryFormatter().Deserialize(stream);
                }
            }
            catch (Exception)
            {
                ids = Enumerable.Range(0, 3160).Select(x => Guid.NewGuid()).ToArray();
                using (var stream = new FileStream(FILENAME, FileMode.CreateNew))
                {
                    new BinaryFormatter().Serialize(stream, ids);
                }
            }
        }

        /// <summary>
        /// Accesses identifier for given pair.
        /// </summary>
        /// <param name="pair">
        /// The pair to get identifier for.
        /// </param>
        /// <returns>
        /// Identifier for given pair.
        /// </returns>
        public Guid this[Pair pair]
        {
            get { return ids[GetPairIndex(pair.Ball1, pair.Ball2)]; }
        }

        private int GetPairIndex(byte ball1, byte ball2)
        {
            if (ball1 > ball2)
            {
                var ball = ball1;
                ball1 = ball2;
                ball2 = ball;
            }

            return (80 - ball1 / 2) * (ball1 - 1) + ball2 - ball1 - 1;
        }
    }
}