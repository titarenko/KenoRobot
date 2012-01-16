using System;
using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Events;

namespace KenoRobot.DomainModel.Entities
{
    /// <summary>
    /// Pair of balls (two balls with distinct numbers from [1, 80] range).
    /// </summary>
    public class Pair : AggregateRoot, 
        IChangeAcceptor<PairAppeared>
    {
        private int lastDrawingNumber;

        /// <summary>
        /// Draws pair (marks that it appeared in given drawing).
        /// </summary>
        /// <param name="drawingNumber">
        /// The drawing number.
        /// </param>
        public void Draw(int drawingNumber)
        {
            if (lastDrawingNumber < drawingNumber)
            {
                ApplyChange(new PairAppeared
                    {
                        PairId = Id,
                        DrawingNumber = drawingNumber
                    });

                ApplyChange(new PairDelayChanged
                    {
                        PairId = Id,
                        Delay = drawingNumber - lastDrawingNumber
                    });
            }

            throw new ApplicationException("Concurrency problem.");
        }

        /// <summary>
        /// Performs changes caused by event.
        /// </summary>
        /// <param name="event">Event to accept.</param>
        public void Accept(PairAppeared @event)
        {
            lastDrawingNumber = @event.DrawingNumber;
        }
    }
}
