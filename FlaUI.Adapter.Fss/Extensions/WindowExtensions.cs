using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinForms = System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core;
using FlaUI.UIA3;

namespace FlaUI.Adapter.Fss.Extensions
{
    public static class WindowExtensions
    {

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static void SetMainWindowPosition(this FlaUI.Core.Application application, int x, int y)
        {
            if (application.IsStoreApp) return;
            using (var automation = new UIA3Automation())
            {
                var mainWindow = application.GetMainWindow(automation);
                Size size = mainWindow.BoundingRectangle.Size;
                //MoveWindow(application.MainWindowHandle, x, y, size.Width, size.Height, true);
                mainWindow.Move(x,y);
            }
        }

        public static void SetMainWindowSize(this FlaUI.Core.Application application, int width, int height)
        {
            using (var automation = new UIA3Automation())
            {
                var mainWindow = application.GetMainWindow(automation);
                Point position = mainWindow.BoundingRectangle.Location;
                MoveWindow(application.MainWindowHandle, position.X, position.Y, width, height, true);
            }
        }

        public static Point GetMainWindowPosition(this FlaUI.Core.Application application)
        {
            using (var automation = new UIA3Automation())
            {
                var mainWindow = application.GetMainWindow(automation);
                var result = mainWindow.BoundingRectangle.Location;
                return result;
            }
        }

        public static Rectangle GetMainWindowSize(this FlaUI.Core.Application application)
        {
            using (var automation = new UIA3Automation())
            {
                var mainWindow = application.GetMainWindow(automation);
                var result = mainWindow.BoundingRectangle;
                return result;
            }
        }
    }
}
