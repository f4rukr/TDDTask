using System;
namespace TDDMicroExercises.TirePressureMonitoringSystem.SomeDependencies
{
    public class AnAlarmClient1
    {
		// A class with the only goal of simulating a dependency on Alert
		// that has impact on the refactoring.
		
        public AnAlarmClient1()
        {
            Alarm anAlarm = new Alarm(new Sensor(), 17.0, 21.0);
            anAlarm.Check();
            bool isAlarmOn = anAlarm.IsAlarmOn;
        }
    }
}
