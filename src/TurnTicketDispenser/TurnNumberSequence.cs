using System.Threading;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;

namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TurnNumberSequenceGenerator : INumberSequenceGenerator
    {
        private static int _turnNumber = 0;

        public int GetNextNumber()
        {
            return Interlocked.Increment(ref _turnNumber);
        }
    }
}
