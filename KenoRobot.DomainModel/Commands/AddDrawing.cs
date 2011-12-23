using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Entities;

namespace KenoRobot.DomainModel.Commands
{
    public class AddDrawing : Command
    {
        public Drawing Drawing { get; set; }
    }
}