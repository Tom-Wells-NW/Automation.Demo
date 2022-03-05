using System.Collections.Generic;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss.Helpers
{
    public interface IProcessDetector
    {
        bool IsProcessRunning(string processName);
        List<Process> GetRunningProcessByName(string processName);
        bool WaitForProcess(string processName);
        bool WaitForProcess(string processName, double timeoutInSeconds, double retryIntervalInSeconds);
    }
}
