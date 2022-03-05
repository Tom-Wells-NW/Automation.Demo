using System.Collections.Generic;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss.Helpers
{
    public class SpecificProcessDetector : ISpecificProcessDetector
    {
        private IProcessDetector _processDetector;
        private readonly string _processName;

        public SpecificProcessDetector(IProcessDetector processDetector, string processName)
        {
            _processDetector = processDetector;
            _processName = processName;
        }

        public string ProcessName => _processName;

        public bool IsProcessRunning()
        {
            var result = _processDetector.IsProcessRunning(_processName);
            return result;
        }

        public List<Process> GetRunningProcesses()
        {
            var result = _processDetector.GetRunningProcessByName(_processName);
            return result;
        }

        public bool WaitForProcess()
        {
            var result = WaitForProcess(30, 0.2);
            return result;
        }

        public bool WaitForProcess(double timeoutInSeconds, double retryIntervalInSeconds)
        {
            if (IsProcessRunning()) return true;
            var result = _processDetector.WaitForProcess(_processName, timeoutInSeconds, retryIntervalInSeconds);
            return result;
        }
    }
}
