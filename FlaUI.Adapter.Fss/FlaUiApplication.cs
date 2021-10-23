using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using System;
using System.Diagnostics;

namespace FlaUI.Adapter.Fss
{
    public class FlaUiApplication
    {
        private Application _application;
        private UIA3Automation _automation;
        private ConditionFactory _by;
        private Window _mainWindow;

        public FlaUiApplication(ProcessStartInfo processStartInfo, TimeSpan applicationLaunchWaitTime)
        {
            _application = FlaUI.Core.Application.AttachOrLaunch(processStartInfo);
            _application.WaitWhileMainHandleIsMissing(applicationLaunchWaitTime);
            Initialize();
        }

        private void Initialize()
        {
            _automation = new UIA3Automation();
            _by = new ConditionFactory(new UIA3PropertyLibrary());
            _mainWindow = _application.GetMainWindow(_automation);
        }

        public Application Application => _application;
        public UIA3Automation Automation => _automation;
        public ConditionFactory By => _by;
        public Window MainWindow => _mainWindow;
    }
}
