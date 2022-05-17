
using System;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TDDMicroExercises.TelemetrySystem
{
    public class TelemetryDiagnosticControls
    {
        private const string DiagnosticChannelConnectionString = "*111#";
        
        private readonly ITelemetryClient _telemetryClient;
        private string _diagnosticInfo = string.Empty;

        public TelemetryDiagnosticControls(ITelemetryClient client)
        {
            _telemetryClient = client;
        }

        public string DiagnosticInfo
        {
            get { return _diagnosticInfo; }
            set { _diagnosticInfo = value; }
        }

        public void CheckTransmission()
        {
            _diagnosticInfo = string.Empty;

            _telemetryClient.Disconnect();

            int retryLeft = 3;
            while (_telemetryClient.IsOnline == false && retryLeft > 0)
            {
                _telemetryClient.Connect(DiagnosticChannelConnectionString);
                retryLeft -= 1;
            }

            if (_telemetryClient.IsOnline)
            {
                _telemetryClient.Send(_telemetryClient.DiagnosticMessage);
                _diagnosticInfo = _telemetryClient.Receive();
            }
        }
    }
}
