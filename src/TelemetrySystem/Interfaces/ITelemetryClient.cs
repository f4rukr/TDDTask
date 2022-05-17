using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDMicroExercises.TelemetrySystem.Interfaces
{
    public interface ITelemetryClient
    {
        bool IsOnline { get; }
        string DiagnosticMessage { get; }

        void Connect(string connectionString);
        void Disconnect();
        void Send(string message);
        string Receive();
    }
}
