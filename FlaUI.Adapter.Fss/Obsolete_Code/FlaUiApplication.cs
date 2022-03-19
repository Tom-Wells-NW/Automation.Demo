using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.UIA3;
using FlaUI.Core.Input;
using FlaUI.Core.WindowsAPI;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using WinForms = System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FlaUI.Adapter.Fss
{
    public class FlaUiApplication : IFlaUiApplication, IDisposable 
    {
        private Application _application;
        private UIA3Automation _automation;
        private ConditionFactory _by;
        private Window _mainWindow;
        private bool disposedValue;

        public FlaUiApplication(string fullyQualifiedFileName, TimeSpan applicationLaunchWaitTime)
        {
            var processStartInfo = CreateProcessStartInfo(fullyQualifiedFileName);
            //_application = FlaUI.Core.Application.Launch(processStartInfo);
            _application = FlaUI.Core.Application.Launch(@"notepad.exe");
            _application.WaitWhileMainHandleIsMissing();
            //_application.WaitWhileMainHandleIsMissing(applicationLaunchWaitTime);
            Initialize();
        }

        public FlaUiApplication(ProcessStartInfo processStartInfo, TimeSpan applicationLaunchWaitTime)
        {
            _application = FlaUI.Core.Application.AttachOrLaunch(processStartInfo);
            _application.WaitWhileMainHandleIsMissing(TimeSpan.FromSeconds(15));
            Initialize();
        }
        private ProcessStartInfo CreateProcessStartInfo(string applicationPath)
        {
            var result = new ProcessStartInfo(applicationPath);
            return result;
        }

        private void Initialize()
        {
            _automation = new UIA3Automation();
            _by = new ConditionFactory(new UIA3PropertyLibrary());
            _mainWindow = _application.GetMainWindow(_automation, TimeSpan.FromSeconds(15));
        }

        public Application Application => _application;
        public UIA3Automation Automation => _automation;
        public ConditionFactory By => _by;
        public Window MainWindow => _mainWindow;

        public void Focus()
        {
            var element = this.Application.GetMainWindow(this.Automation).FindFirstChild();
            element.Focus();
            this.Automation.OverlayManager.Size = 6;
            this.Automation.OverlayManager.ShowBlocking(this.MainWindow.BoundingRectangle, System.Drawing.Color.Red, 500);
        }

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public void SetMainWindowSize(int width, int height)
        {
            Point position = _mainWindow.BoundingRectangle.Location;
            MoveWindow(_application.MainWindowHandle, position.X, position.Y, width, height, true);
        }
        public Size GetMainWindowSize()
        {
            var result = _mainWindow.BoundingRectangle.Size;
            return result;
        }

        public void SetMainWindowPosition(int x, int y)
        {
            Size size = _mainWindow.BoundingRectangle.Size;
            MoveWindow(_application.MainWindowHandle, x, y, size.Width, size.Height, true);
        }

        public Point GetMainWindowPosition()
        {
            var result = _mainWindow.BoundingRectangle.Location;
            return result;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _automation.Dispose();
                    _application.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                _automation = null;
                _application = null;
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~FlaUiApplication()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
