using FlaUI.Core.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FlaUI.Adapter.Fss.Helpers
{
    public class ProcessDetector : IProcessDetector
    {
        public bool IsProcessRunning(string processName)
        {
            var result = Process.GetProcesses()
                                .Any(p => p.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase));
            return result;
        }

        public List<Process> GetRunningProcessByName(string processName)
        {
            var result = new List<Process>();
            if (!IsProcessRunning(processName)) return result;

            result = Process.GetProcesses()
                            .Where(p => p.ProcessName.Equals(processName, StringComparison.InvariantCultureIgnoreCase))
                            .ToList();
            return result;
        }

        public bool WaitForProcess(string processName)
        {
            var result = WaitForProcess(processName, 30, 1);
            return result;
        }

        public bool WaitForProcess(string processName, double timeoutInSeconds, double retryIntervalInSeconds)
        {
            var result = false;

            var retry = Retry.WhileFalse
                (
                    () => IsProcessRunning(processName),
                    TimeSpan.FromSeconds(Math.Abs(timeoutInSeconds)),
                    TimeSpan.FromSeconds(Math.Abs(retryIntervalInSeconds))
                );
            if (retry.Success) result = retry.Success;

            return result;
        }
    }
}
