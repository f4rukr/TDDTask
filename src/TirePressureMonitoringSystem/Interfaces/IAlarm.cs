using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TirePressureMonitoringSystem.Interfaces
{
    public interface IAlarm
    {
        bool IsAlarmOn { get; }

        void Check();
    }
}
