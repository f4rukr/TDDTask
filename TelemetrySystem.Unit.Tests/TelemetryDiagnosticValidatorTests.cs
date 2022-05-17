using Moq;
using TDDMicroExercises.TelemetrySystem;
using TDDMicroExercises.TelemetrySystem.Interfaces;
using TelemetrySystem.Unit.Tests.Stubs;
using Xunit;

namespace TelemetrySystem.Unit.Tests
{
    public class TelemetryDiagnosticValidatorTests
    {
        private const string DIAGNOSTIC_MESSAGE = "AT#UD";
        private const string RESPONSE_MESSAGE = "OK";
        private const string CHANNEL_CONNECTION_STRING = "*111#";

        [Theory]
        [InlineData(CHANNEL_CONNECTION_STRING, DIAGNOSTIC_MESSAGE)]
        public void Should_Call_Methods_On_CheckTransmission(string connString, string diagnosticMessage)
        {
            //Arrange
            var _telemetryClientMock = new Mock<ITelemetryClient>();
            var telemetryDiagnostic = new TelemetryDiagnosticControls(_telemetryClientMock.Object);

            //Act 
            telemetryDiagnostic.CheckTransmission();

            //Assert
            _telemetryClientMock.Verify(x => x.Disconnect(), Times.Once);
            _telemetryClientMock.Verify(x => x.Connect(connString), Times.AtLeastOnce);
            _telemetryClientMock.Verify(x => x.Send(diagnosticMessage), Times.AtMostOnce);
            _telemetryClientMock.Verify(x => x.Receive(), Times.AtMostOnce);
        }

        [Theory]
        [InlineData(DIAGNOSTIC_MESSAGE, RESPONSE_MESSAGE)]
        public void Should_Send_Diagnostic_Message_And_Receive_Status_Message(string diagnosticMessage, string responseMessage)
        {
            //Arrange
            var telemetryClientStub = new StubTelemetryClient();
            telemetryClientStub.SetupData(diagnosticMessage, responseMessage);
            var telemetryDiagnostic = new TelemetryDiagnosticControls(telemetryClientStub);

            //Act 
            telemetryDiagnostic.CheckTransmission();

            //Assert
            telemetryClientStub.Verify();
        }
    }
}