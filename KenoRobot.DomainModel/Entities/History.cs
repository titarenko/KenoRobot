using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Events;

namespace KenoRobot.DomainModel.Entities
{
    public class History : AggregateRoot,
        IChangeAcceptor<DrawingAdded>
    {
        private int lastDrawingNumber;

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

        public void Accept(DrawingAdded @event)
        {
            lastDrawingNumber = @event.Drawing.Number;
        }
    }
}