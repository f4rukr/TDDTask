using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser : ITicketDispenser
    {
        private readonly INumberSequenceGenerator _numberSequenceGenerator;

        public TicketDispenser(INumberSequenceGenerator numberSequence)
        {
            _numberSequenceGenerator = numberSequence;
        }

        public TurnTicket GetTurnTicket()
        {
            int newNumber = _numberSequenceGenerator.GetNextNumber();
            var newTicket = new TurnTicket(newNumber);

            return newTicket;
        }
    }
}
