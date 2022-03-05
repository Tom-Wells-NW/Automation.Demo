using System.Collections.Generic;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss.Helpers
{
    public interface ISpecificProcessDetector
    {
        string ProcessName { get; }
        bool IsProcessRunning();
        List<Process> GetRunningProcesses();
        bool WaitForProcess();
        bool WaitForProcess(double timeoutInSeconds, double retryIntervalInSeconds);
    }
}
