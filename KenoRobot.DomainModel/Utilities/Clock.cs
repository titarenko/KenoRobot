using System;

namespace KenoRobot.DomainModel.Utilities
{
    /// <summary>
    /// Represents world's (system's) clock.
    /// </summary>
    /// <remarks>
    /// Always use <code>Clock.Now</code> instead of 
    /// <code>DateTime.Now</code> to maintain high testability.
    /// </remarks>
    public class Clock
    {
        private static DateTime? freezedValue;

        /// <summary>
        /// Gets current date and time.
        /// </summary>
        public static DateTime Now
        {
            get { return freezedValue ?? DateTime.Now; }
        }

        /// <summary>
        /// Sets value and freezes the clock.
        /// </summary>
        /// <param name="dateTime">
        /// The date time.
        /// </param>
        public static void SetAndFreeze(DateTime? dateTime = null)
        {
            freezedValue = dateTime;
        }
    }
}
