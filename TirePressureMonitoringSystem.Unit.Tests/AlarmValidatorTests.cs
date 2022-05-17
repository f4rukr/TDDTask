using FluentAssertions;
using Moq;
using TDDMicroExercises.TirePressureMonitoringSystem;
using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;
using Xunit;

namespace TirePressureMonitoringSystem.Unit.Tests
{
    public class AlarmValidatorTests
    {
        private const int LOW_PRESSURE_THRESHOLD = 17;
        private const int HIGH_PRESSURE_THRESHOLD = 21;
        private const int BELLOW_THRESHOLD = 16;
        private const int ABOVE_THRESHOLD = 22;
        private const int BETWEEN_THRESHOLD_0 = 17;
        private const int BETWEEN_THRESHOLD_1 = 18;
        private const int BETWEEN_THRESHOLD_2 = 21;

        private readonly Mock<ISensor> _sensorMock;

        public AlarmValidatorTests()
        {
            _sensorMock = new Mock<ISensor>();
        }

        [Theory]
        [InlineData(BELLOW_THRESHOLD, LOW_PRESSURE_THRESHOLD, HIGH_PRESSURE_THRESHOLD)]
        [InlineData(ABOVE_THRESHOLD, LOW_PRESSURE_THRESHOLD, HIGH_PRESSURE_THRESHOLD)]
        public void Should_Alarm_Set_To_Active_When_Psi_Value_Is_Not_Between_Threshold_Values(double psiPressureValue, double lowPressureThreshold, double highPressureThreshold)
        {
            //Arrange
            IAlarm alarm = new Alarm(_sensorMock.Object, lowPressureThreshold, highPressureThreshold);
            _sensorMock.Setup(s => s.PopNextPressurePsiValue())
                       .Returns(psiPressureValue);

            //Act
            alarm.Check();

            //Assert
            _sensorMock.Verify(s => s.PopNextPressurePsiValue(), Times.Once);
            alarm.IsAlarmOn.Should().BeTrue();
        }

        [Theory]
        [InlineData(BETWEEN_THRESHOLD_0, LOW_PRESSURE_THRESHOLD, HIGH_PRESSURE_THRESHOLD)]
        [InlineData(BETWEEN_THRESHOLD_1, LOW_PRESSURE_THRESHOLD, HIGH_PRESSURE_THRESHOLD)]
        [InlineData(BETWEEN_THRESHOLD_2, LOW_PRESSURE_THRESHOLD, HIGH_PRESSURE_THRESHOLD)]
        public void Should_Alarm_Set_To_InActive_When_Psi_Value_Is_Between_Threshold_Values(double psiPressureValue, double lowPressureThreshold, double highPressureThreshold)
        {
            //Arrange
            IAlarm alarm = new Alarm(_sensorMock.Object, lowPressureThreshold, highPressureThreshold);
            _sensorMock.Setup(s => s.PopNextPressurePsiValue())
                       .Returns(psiPressureValue);

            //Act
            alarm.Check();

            //Assert
            _sensorMock.Verify(s => s.PopNextPressurePsiValue(), Times.Once);
            alarm.IsAlarmOn.Should().BeFalse();
        }
    }
}