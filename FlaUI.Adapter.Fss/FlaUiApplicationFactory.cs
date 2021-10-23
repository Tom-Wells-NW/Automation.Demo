using System;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss
{
    public class FlaUiApplicationFactory
    {
        public FlaUiApplication AttachOrCreate(string applicationPath, TimeSpan applicationLaunchWaitTime)
        {
            var processStartInfo = CreateProcessStartInfo(applicationPath);
            var result = new FlaUiApplication(processStartInfo, applicationLaunchWaitTime);
            WaitForProccessIfNotRunning(applicationPath);
            return result;
        }

        private ProcessStartInfo CreateProcessStartInfo(string applicationPath)
        {
            var result = new ProcessStartInfo(applicationPath);
            return result;
        }

        private void WaitForProccessIfNotRunning(string applicationPath, double timeoutInSeconds = 15)
        {
            // TODO: Implement here
        }
    }
}
