using FlaUI.Adapter.Fss.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using System.Windows.Forms;

namespace FlaUI.Adapter.Fss.MSUnitTests
{
    [TestClass]
    public class FlaUiApplicationFactoryTests
    {
        [TestMethod]
        public void Can_create_a_fla_ui_application_from_a_factory()
        {
            var fqn = @"c:\windows\notepad.exe";
            var sut = new FlaUiApplicationFactory(new SpecificProcessDetectorFactory());
            var application = sut.AttachOrCreate(fqn, 2);

            //application.MainWindow.

            //var element = application.Application.GetMainWindow(application.Automation).FindFirstChild();
            //element.Focus();
            //application.Automation.OverlayManager.Size = 2;
            //application.Automation.OverlayManager.ShowBlocking(application.MainWindow.BoundingRectangle, System.Drawing.Color.Green, 3000);
            application.Focus();
            application.SetSizeApproximate(400, 400);
        }

        [TestMethod]
        public void Can_create_a_fla_ui_application_from_a_factory_and_record_window_size()
        {
            var fqn = @"c:\windows\notepad.exe";
            var sut = new FlaUiApplicationFactory(new SpecificProcessDetectorFactory());
            var application = sut.AttachOrCreate(fqn, 2);
            application.Focus();
            
            var approximateSize = application.GetSizeApproximate();
            Console.WriteLine($"bounding rect: {approximateSize}");
        }

        [TestMethod]
        public void Can_create_a_fla_ui_application_from_a_factory_and_move_the_window()
        {
            //var screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            //var screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;

            Console.WriteLine($"Screens: ");
            int i = 0;
            foreach(var screen in Screen.AllScreens)
            {
                var bounds = screen.WorkingArea;
                Console.WriteLine($"Screen[{i}] IsPrimary:{screen.Primary}  bounds: TopLeft(x, y): ({bounds.Left}, {bounds.Top}) BottomRight(x, y): ({bounds.Right}, {bounds.Bottom}) ");
                i++;
            }
            

            //System.Windows.SystemParameters.PrimaryScreenHeight
            //var x = System.Windows.
            var fqn = @"c:\windows\notepad.exe";
            var sut = new FlaUiApplicationFactory(new SpecificProcessDetectorFactory());
            var application = sut.AttachOrCreate(fqn, 10);
            for (int c = 0; c < 5; c++)
            {
                int x = (c * 10);
                int y = (c * 5);
                var boundary = application.MainWindow.BoundingRectangle;
                application.MainWindow.Move(boundary.X + x, boundary.Y + y);
                
                Thread.Sleep(20);
            }
        }
    }
}