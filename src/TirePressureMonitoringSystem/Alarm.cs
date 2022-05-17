using TDDMicroExercises.TirePressureMonitoringSystem.Interfaces;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class Alarm : IAlarm
    {
        private double _lowPressureThreshold;
        private double _highPressureThreshold;
        private bool _alarmOn = false;
        private readonly ISensor _sensor;


        public Alarm(ISensor sensor, double lowPressureThreshold, double highPressureThreshold)
        {
            _sensor = sensor;
            _lowPressureThreshold = lowPressureThreshold;
            _highPressureThreshold = highPressureThreshold;
        }

        public void Check()
        {
            double psiPressureValue = _sensor.PopNextPressurePsiValue();

            if (psiPressureValue < _lowPressureThreshold || psiPressureValue > _highPressureThreshold)
                _alarmOn = true;
            else
                _alarmOn = false;
        }

        public bool IsAlarmOn
        {
            get 
            {
                return _alarmOn; 
            }
        }
    }
}
