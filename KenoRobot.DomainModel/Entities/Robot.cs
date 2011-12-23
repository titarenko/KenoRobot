using System;
using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Utilities;

namespace KenoRobot.DomainModel.Entities
{
    public class Robot : AggregateRoot,
        IChangeAcceptor<RobotCreated>
    {
        public Robot()
        {
        }

        public Robot(Guid id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name is not specified.", "name");
            }

            ApplyChange(new RobotCreated
                {
                    Id = id,
                    Name = name,
                    Date = Clock.Now
                });
        }

        public void Accept(RobotCreated @event)
        {
            id = @event.Id;
        }
    }

    public class RobotCreated : Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}