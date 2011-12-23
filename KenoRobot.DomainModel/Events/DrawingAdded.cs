using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Events
{
    public class DrawingAdded : Event
    {
        public Drawing Drawing { get; set; }
    }
}