using FlaUI.Adapter.Fss.Helpers;
using System;
using System.Threading;

namespace FlaUI.Adapter.Fss.TestHarness_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Test_02(2);

            Test_02(2);
            PauseFor(2);

            Test_02(5);
        }

        public static void Test_01()
        {
            for (int i = 0; i < 5; i++)
            {
 
                var fqn = @"c:\windows\notepad.exe";
 
                var sut = new FlaUiApplicationFactory(new SpecificProcessDetectorFactory());
                var application = sut.AttachOrCreate(fqn, 2);

                application.Focus();

                application.SetSizeApproximate(600, 600);
                PauseFor(1);
                application.SetSizeApproximate(400, 400);
                PauseFor(1);
                application.SetSizeApproximate(400, 400);
                PauseFor(1);
                application.SetSizeApproximate(400, 400);
                PauseFor(1);
            }
        }


        public static void Test_02(int iterations)
        {

            for (int i = 0; i < iterations; i++)
            {
                var fqn = @"c:\windows\notepad.exe";
                var sut = new FlaUiApplicationFactory(new SpecificProcessDetectorFactory());
                var application = sut.Create(fqn, 2);

                application.Focus();

                application.SetSizeApproximate(600, 600);
                PauseFor(.5);
                application.SetSizeApproximate(400, 400);
                PauseFor(.5);
                application.SetSizeApproximate(400, 400);
                PauseFor(.5);
                application.SetSizeApproximate(400, 400);
                PauseFor(.5);
            }
        }

        public static void PauseFor(double delayInSeconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(delayInSeconds));
        }
    }
}
