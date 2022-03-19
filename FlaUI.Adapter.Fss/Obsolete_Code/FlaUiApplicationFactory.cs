using FlaUI.Adapter.Fss.Helpers;
using System;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss
{
    public class FlaUiApplicationFactory
    {
        private readonly ISpecificProcessDetectorFactory _processDetectorFactory;
        public FlaUiApplicationFactory(ISpecificProcessDetectorFactory processDetectorFactory)
        {
            _processDetectorFactory = processDetectorFactory;
        }

        public FlaUiApplication AttachOrCreate(string applicationPath, double applicationLaunchWaitTimeInSeconds = 3.0)
        {
            var processStartInfo = CreateProcessStartInfo(applicationPath);
            var applicationLaunchWaitTime = TimeSpan.FromSeconds(Math.Abs(applicationLaunchWaitTimeInSeconds));

            var result = new FlaUiApplication(processStartInfo, applicationLaunchWaitTime);
            var specificProcessDetector = _processDetectorFactory.Create(applicationPath);
            specificProcessDetector.WaitForProcess(30, 0.3);
            return result;
        }

        public FlaUiApplication Create(string applicationPath, double applicationLaunchWaitTimeInSeconds = 3.0)
        {
            var applicationLaunchWaitTime = TimeSpan.FromSeconds(Math.Abs(applicationLaunchWaitTimeInSeconds));

            var result = new FlaUiApplication(applicationPath, applicationLaunchWaitTime);
            var specificProcessDetector = _processDetectorFactory.Create(applicationPath);
            specificProcessDetector.WaitForProcess(30, 0.3);
            return result;
        }

        private ProcessStartInfo CreateProcessStartInfo(string applicationPath)
        {
            var result = new ProcessStartInfo(applicationPath);
            return result;
        }
    }
}