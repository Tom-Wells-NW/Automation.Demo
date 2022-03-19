using FlaUI.Adapter.Fss.Helpers;
using FluentAssertions.Execution;
using System;
using TechTalk.SpecFlow;

namespace FlaUI.Adapter.Fss.Specs.StepDefinitions
{
    [Binding]
    public class FlaUiApplicationStepDefinitions
    {
        //private FlaUiApplication _application;

        [Given(@"I have launched an application (.*)")]
        public void Given_I_have_launched_an_application(string applicationPath)
        {
            var fqn = @"c:\windows\notepad.exe";
            //_application = new FlaUiApplication(fqn, TimeSpan.FromSeconds(2));
            //_application.Focus();
            Thread.Sleep(2000);
        }

        [When(@"I move the application window to a new (.*) and (.*) screen position")]
        public void When_I_move_the_application_window_to_a_new_screen_position(int x, int y)
        {
            //_application.SetMainWindowPosition(x, y);
        }

        [Then(@"I expect the window's new position to be \((.*), (.*)\)")]
        public void Then_I_expect_the_windows_new_position_to_be(int x, int y)
        {
            //var _actualPosition = _application.GetMainWindowPosition();
            //_application.Application.Close();
            //using (new AssertionScope())
            //{
            //    _actualPosition.X.Should().Be(x);
            //    _actualPosition.Y.Should().Be(y);
            //}
        }

        [When(@"I resize the application window to a new (.*) and (.*)")]
        public void When_I_resize_the_application_window_to_a_new_position(int width, int height)
        {
            //_application.SetMainWindowSize(width, height);
        }

        [Then(@"I expect the window's new size to be \((.*), (.*)\) pixels")]
        public void Then_I_expect_the_windows_new_size_to_be(int width, int height)
        {
            //var _actualSize = _application.GetMainWindowSize();
            //_application.Application.Close();
            //_application.Dispose();
            //using (new AssertionScope())
            //{
            //    _actualSize.Width.Should().Be(width);
            //    _actualSize.Height.Should().Be(height);
            //}
        }
    }
}
