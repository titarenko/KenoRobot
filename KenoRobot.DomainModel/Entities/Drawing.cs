using System;
using System.Linq;

namespace KenoRobot.DomainModel.Entities
{
    /// <summary>
    /// Represents KENO drawing.
    /// </summary>
    public class Drawing
    {
        private readonly DateTime firstDrawingDate = new DateTime(2001, 4, 11);

        private int number;
        private DateTime date;
        private char engine;
        private byte ballsComplect;
        private byte[] balls;

        /// <summary>
        /// Gets or sets number.
        /// </summary>
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("value", "Number should not be less than 1.");
                }

                number = value;
            }
        }

        /// <summary>
        /// Gets or sets date.
        /// </summary>
        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                if (value < firstDrawingDate)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", "Date should not be less than April 11, 2011.");
                }

                date = value;
            }
        }

        /// <summary>
        /// Gets or sets engine ('À' or 'Á').
        /// </summary>
        public char Engine
        {
            get
            {
                return engine;
            }

            set
            {
                if (engine != 'À' && engine != 'Á')
                {
                    throw new ArgumentOutOfRangeException(
                        "value", "Allowed values are only 'À' and 'Á'.");
                }

                engine = value;
            }
        }

        /// <summary>
        /// Gets or sets balls complect.
        /// </summary>
        public byte BallsComplect
        {
            get
            {
                return ballsComplect;
            }

            set
            {
                if (value < 1 || value > 4)
                {
                    throw new ArgumentOutOfRangeException(
                        "value", "Balls complect number should fall into [1, 4] interval.");
                }

                ballsComplect = value;
            }
        }

        /// <summary>
        /// Gets or sets balls.
        /// </summary>
        public byte[] Balls
        {
            get
            {
                return balls;
            }

            set
            {
                if (value.Any(x => x < 1 || x > 80))
                {
                    throw new ArgumentOutOfRangeException(
                        "value", "Ball number should fall into [1, 80] interval.");
                }

                if (value.Any(x => value.Count(y => x == y) > 1))
                {
                    throw new ArgumentException(
                        "Ball number should be unique within drawing.", "value");
                }

                balls = value;
            }
        }
    }
}
