using System;
namespace TDDMicroExercises.TurnTicketDispenser.SomeDependencies
{
    public class TurnNumberSequenceClient
    {
		// A class with the only goal of simulating a dependency on TurnNumberSequence
		// that has impact on the refactoring.

		public TurnNumberSequenceClient()
        {
            TurnNumberSequenceGenerator turnNumberSequence = new TurnNumberSequenceGenerator();
            int nextUniqueTicketNumber = turnNumberSequence.GetNextNumber();
            nextUniqueTicketNumber = turnNumberSequence.GetNextNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextNumber();
			nextUniqueTicketNumber = turnNumberSequence.GetNextNumber();
		}
    }
}
