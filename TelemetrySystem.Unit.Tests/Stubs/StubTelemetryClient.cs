using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TelemetrySystem.Interfaces;

namespace TelemetrySystem.Unit.Tests.Stubs
{
    public class StubTelemetryClient : ITelemetryClient
    {
        public bool IsOnline { get { return _onlineStatus; } }

        public string DiagnosticMessage
        {
            get { return "AT#UD"; }
        }

        private bool _onlineStatus;
        private string _expectedMessageToSend;
        private string _expectedMessageToReceive;
        private string _actualMessageToSend;

        public void Connect(string connectionString)
        {
            _onlineStatus = true;
        }

        public void Disconnect()
        {
            _onlineStatus = false;
        }

        public string Receive()
        {
            return _expectedMessageToReceive;
        }

        public void Send(string message)
        {
            _actualMessageToSend = message;
        }

        internal void SetupData(string expectedMessageToSend, string expectedMessageToReceive)
        {
            _expectedMessageToSend = expectedMessageToSend;
            _expectedMessageToReceive = expectedMessageToReceive;
        }

        public void Verify()
        {
            if (_expectedMessageToSend != _actualMessageToSend)
            {
                throw new ArgumentOutOfRangeException("Send message is ", _actualMessageToSend, ", but expected is'" + _expectedMessageToSend + "'.");
            }
        }
    }
}
