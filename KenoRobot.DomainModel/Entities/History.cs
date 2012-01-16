using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Events;

namespace KenoRobot.DomainModel.Entities
{
    /// <summary>
    /// History of KENO drawings.
    /// </summary>
    /// <remarks>
    /// Singleton by definition.
    /// </remarks>
    public class History : AggregateRoot, 
        IChangeAcceptor<DrawingAdded>
    {
        private int lastDrawingNumber;

        /// <summary>
        /// Adds drawing to history.
        /// </summary>
        /// <param name="drawing">
        /// The drawing.
        /// </param>
        public void AddDrawing(Drawing drawing)
        {
            if (drawing.Number > lastDrawingNumber)
            {
                ApplyChange(new DrawingAdded
                    {
                        Drawing = drawing
                    });
            }
        }

        /// <summary>
        /// Performs changes caused by event.
        /// </summary>
        /// <param name="event">Event to accept.</param>
        public void Accept(DrawingAdded @event)
        {
            lastDrawingNumber = @event.Drawing.Number;
        }
    }
}
