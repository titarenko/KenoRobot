using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Commands;
using KenoRobot.DomainModel.Events;
using KenoRobot.DomainModel.Utilities;

namespace KenoRobot.DomainModel.Handlers
{
    /// <summary>
    /// Saga for processing of just added drawing.
    /// </summary>
    public class DrawingProcessorSaga :
        IEventHandler<DrawingAdded>
    {
        private readonly IBus bus;
        private readonly IPairIdCollection collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawingProcessorSaga"/> class.
        /// </summary>
        /// <param name="bus">
        /// The bus.
        /// </param>
        /// <param name="collection">
        /// The pair id collection.
        /// </param>
        public DrawingProcessorSaga(IBus bus, IPairIdCollection collection)
        {
            this.bus = bus;
            this.collection = collection;
        }

        /// <summary>
        /// Issues IndicatePairAppeared commands for drawing that was just added.
        /// </summary>
        /// <param name="event">
        /// The event.
        /// </param>
        public void Handle(DrawingAdded @event)
        {
            var balls = @event.Drawing.Balls;

            for (var i = 0; i < 20 - 1; ++i)
            {
                for (var j = i + 1; j < 20; ++j)
                {
                    bus.Send(new IndicatePairAppeared
                        {
                            PairId = collection.GetId(balls[i], balls[j]),
                            DrawingNumber = @event.Drawing.Number
                        });
                }
            }
        }
    }
}
