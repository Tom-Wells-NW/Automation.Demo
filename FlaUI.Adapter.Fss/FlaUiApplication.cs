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

namespace FlaUI.Adapter.Fss
{
    public class FlaUiApplication : IFlaUiApplication
    {
        private Application _application;
        private UIA3Automation _automation;
        private ConditionFactory _by;
        private Window _mainWindow;

        public FlaUiApplication(string fullyQualifiedFileName, TimeSpan applicationLaunchWaitTime)
        {
            var processStartInfo = CreateProcessStartInfo(fullyQualifiedFileName);
            _application = FlaUI.Core.Application.Launch(processStartInfo);
            _application.WaitWhileMainHandleIsMissing(applicationLaunchWaitTime);
            Initialize();
        }

        public FlaUiApplication(ProcessStartInfo processStartInfo, TimeSpan applicationLaunchWaitTime)
        {
            _application = FlaUI.Core.Application.AttachOrLaunch(processStartInfo);
            _application.WaitWhileMainHandleIsMissing(applicationLaunchWaitTime);
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
            _mainWindow = _application.GetMainWindow(_automation);
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

        public System.Drawing.Rectangle GetSizeApproximate()
        {
            var element = this.Application.GetMainWindow(this.Automation).FindFirstChild();
            var currentSize = element.BoundingRectangle;
            return currentSize;
        }

        public void SetSizeApproximate(int targetWidth, int targetHeight)
        {
            var element = this.Application.GetMainWindow(this.Automation).FindFirstChild();
            var currentSize = element.BoundingRectangle;

            var widthDelta = targetWidth - currentSize.Width;
            int interationsWidth = 0;

            for (int x = 0; x < (double)Math.Abs(widthDelta) / 14.2; x++)
            {
                if (widthDelta < 0) ShrinkWidth();
                if (widthDelta > 0) GrowWidth();
                interationsWidth = x;
            }


            var heightDelta = targetWidth - currentSize.Height;
            int interationsHeight = 0;

            for (int y = 0; y < (double)Math.Abs(heightDelta) / 11.9; y++)
            {
                if (heightDelta < 0)
                {
                    ShrinkHeight();
                }
                if (heightDelta > 0) GrowHeight();

                interationsHeight = y;
            }

            var newSize = element.BoundingRectangle;
            Console.WriteLine($"start bounding rect: {currentSize}");
            Console.WriteLine($"expected delta Width: {widthDelta} expected delta Height: {heightDelta}");
            Console.WriteLine($"interations Width: {interationsWidth} interations Height: {interationsHeight}");
            Console.WriteLine($"end bounding rect: {element.BoundingRectangle}");
            Console.WriteLine($"actual delta Width: {targetWidth - element.BoundingRectangle.Width} actual delta Height: {targetHeight - element.BoundingRectangle.Height}");
        }


        private void GrowHeight()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.SPACE);
            Keyboard.Type(VirtualKeyShort.KEY_S);
            Keyboard.Type(VirtualKeyShort.DOWN);
            Keyboard.Type(VirtualKeyShort.DOWN);
            Keyboard.Type(VirtualKeyShort.DOWN);
            Keyboard.Type(VirtualKeyShort.ENTER);
        }

        private void ShrinkHeight()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.SPACE);
            Keyboard.Type(VirtualKeyShort.KEY_S);
            Keyboard.Type(VirtualKeyShort.DOWN);
            Keyboard.Type(VirtualKeyShort.UP);
            Keyboard.Type(VirtualKeyShort.UP);
            Keyboard.Type(VirtualKeyShort.ENTER);
        }


        private void GrowWidth()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.SPACE);
            Keyboard.Type(VirtualKeyShort.KEY_S);
            Keyboard.Type(VirtualKeyShort.RIGHT);
            Keyboard.Type(VirtualKeyShort.RIGHT);
            Keyboard.Type(VirtualKeyShort.RIGHT);
            Keyboard.Type(VirtualKeyShort.ENTER);
        }

        private void ShrinkWidth()
        {
            Keyboard.TypeSimultaneously(VirtualKeyShort.ALT, VirtualKeyShort.SPACE);
            Keyboard.Type(VirtualKeyShort.KEY_S);
            Keyboard.Type(VirtualKeyShort.RIGHT);
            Keyboard.Type(VirtualKeyShort.LEFT);
            Keyboard.Type(VirtualKeyShort.LEFT);
            Keyboard.Type(VirtualKeyShort.ENTER);
        }

    }
}
