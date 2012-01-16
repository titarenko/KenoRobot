using Cqrsnes.Infrastructure;
using KenoRobot.DomainModel.Events;
using KenoRobot.DomainModel.Utilities;

namespace KenoRobot.DomainModel.Handlers
{
    /// <summary>
    /// Calculates properties of pairs such as probability of appearance and so on.
    /// </summary>
    public class PairPropertiesCalculatorSaga : IEventHandler<PairDelayChanged>
    {
        private readonly IBus bus;
        private readonly IPairAppearanceProbabilityCalculator calculator;

        /// <summary>
        /// Initializes a new instance of the <see cref="PairPropertiesCalculatorSaga"/> class.
        /// </summary>
        /// <param name="bus">
        /// The bus.
        /// </param>
        /// <param name="calculator">
        /// The calculator.
        /// </param>
        public PairPropertiesCalculatorSaga(IBus bus, IPairAppearanceProbabilityCalculator calculator)
        {
            this.bus = bus;
            this.calculator = calculator;
        }

        /// <summary>
        /// Handles (reacts to) event.
        /// </summary>
        /// <param name="event">Event instance.</param>
        public void Handle(PairDelayChanged @event)
        {
            bus.Publish(new PairAppearanceProbabilityChanged
                {
                    PairId = @event.PairId,
                    Probability = calculator.GetAppearanceProbability(@event.Delay)
                });
        }
    }
}
