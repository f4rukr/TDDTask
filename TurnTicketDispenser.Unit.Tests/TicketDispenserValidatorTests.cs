using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDDMicroExercises.TurnTicketDispenser;
using TDDMicroExercises.TurnTicketDispenser.Interfaces;
using Xunit;

namespace TurnTicketDispenser.Unit.Tests
{
    public class TicketDispenserValidatorTests
    {
        [Fact]
        public void Should_Generate_New_Ticket_Number_Same_Machine()
        {
            //Arrange
            ITicketDispenser ticketDispenser = new TicketDispenser(new TurnNumberSequenceGenerator());

            //Act
            TurnTicket firstTicket = ticketDispenser.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser.GetTurnTicket();

            //Assert
            secondTicket.TurnNumber.Should().BeGreaterThan(firstTicket.TurnNumber);
        }

        [Fact]
        public void Should_Generate_New_Ticket_Number_Different_Machine()
        {
            //Arrange
            ITicketDispenser ticketDispenser1 = new TicketDispenser(new TurnNumberSequenceGenerator());
            ITicketDispenser ticketDispenser2 = new TicketDispenser(new TurnNumberSequenceGenerator());

            //Act
            TurnTicket firstTicket = ticketDispenser1.GetTurnTicket();
            TurnTicket secondTicket = ticketDispenser2.GetTurnTicket();

            //Assert
            secondTicket.TurnNumber.Should().BeGreaterThan(firstTicket.TurnNumber);
        }


        private const int DISTINCT_NUMBER_OF_TICKETS = 10;
        [Fact]
        public async void Should_Generate_Distinct_Ticket_Numbers_Async()
        {
            //Arrange
            ITicketDispenser ticketDispenser = new TicketDispenser(new TurnNumberSequenceGenerator());

            //Act
            Task<TurnTicket> task1 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task2 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task3 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task4 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task5 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task6 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task7 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task8 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task9 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task<TurnTicket> task10 = Task.Run(() => ticketDispenser.GetTurnTicket());
            Task.WaitAll(task1, task2, task3, task4, task5, task6, task7, task8, task9, task10);

            var tickets = new List<int>() 
            { 
                (await task1).TurnNumber, 
                (await task2).TurnNumber, 
                (await task3).TurnNumber, 
                (await task4).TurnNumber, 
                (await task5).TurnNumber,
                (await task6).TurnNumber,
                (await task7).TurnNumber,
                (await task8).TurnNumber,
                (await task9).TurnNumber,
                (await task10).TurnNumber,
            };

            //Assert
            tickets.Distinct().Count().Should().Be(DISTINCT_NUMBER_OF_TICKETS);
        }

        private const int TICKET_NUMBER = 5;

        [Theory]
        [InlineData(TICKET_NUMBER)]
        public async void Should_Generate_Valid_Ticket_Number(int ticketNumber)
        {
            //Arrange
            var turnNumberSequenceGeneratorMock = new Mock<INumberSequenceGenerator>();
            turnNumberSequenceGeneratorMock.Setup(x => x.GetNextNumber())
                                           .Returns(ticketNumber);

            //Act
            int newTicketNumber = turnNumberSequenceGeneratorMock.Object.GetNextNumber();
            var newTicket = new TurnTicket(newTicketNumber);

            //Assert
            newTicket.TurnNumber.Should().Be(TICKET_NUMBER);
            turnNumberSequenceGeneratorMock.Verify(s => s.GetNextNumber(), Times.Once);
        }
    }
}