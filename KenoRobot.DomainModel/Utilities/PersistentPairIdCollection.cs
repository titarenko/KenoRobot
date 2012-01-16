using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Implements file storage for ids of pairs.
    /// </summary>
    public class PersistentPairIdCollection : IPairIdCollection
    {
        private const string FILE_NAME = "ids.bin";

        private readonly Guid[] ids;

        /// <summary>
        /// Initializes a new instance of the <see cref="PersistentPairIdCollection"/> class.
        /// </summary>
        public PersistentPairIdCollection()
        {
            try
            {
                using (var stream = new FileStream(FILE_NAME, FileMode.Open))
                {
                    ids = (Guid[]) new BinaryFormatter().Deserialize(stream);
                }
            }
            catch (Exception)
            {
                ids = Enumerable.Range(0, 3160).Select(x => Guid.NewGuid()).ToArray();
                using (var stream = new FileStream(FILE_NAME, FileMode.CreateNew))
                {
                    new BinaryFormatter().Serialize(stream, ids);
                }
            }
        }

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
        public Guid GetId(byte ball1, byte ball2)
        {
            return ids[GetPairIndex(ball1, ball2)];
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
