using FlaUI.Adapter.Fss.Extensions;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FluentAssertions.Execution;
using System;
using System.Drawing;
using TechTalk.SpecFlow;


namespace FlaUI.Adapter.Fss.Specs.StepDefinitions
{
    [Binding]
    public class FlaUIApplicationExtensionsStepDefinitions : StepDefinitionBase
    {
        private Application _application;


        [Given(@"I have a Test Case: (.*)")]
        public void Given_I_have_a_test_case_P0(string testCaseId)
        {
            OutputIndented($"Test Case ID: {testCaseId}");
        }


        [Given]
        public void Given_I_have_launched_an_application_type_P0_named_P1(bool isWindowsStoreApp, string application)
        {
            OutputIndented($"Launching application: {application}");
            if (isWindowsStoreApp)
                _application = Application.LaunchStoreApp(application);
            else
                _application = Application.Launch(application);
        }

        [When(@"I move the application window to a new (.*) and (.*) screen position")]
        public void When_I_move_the_application_window_to_a_new_P0_and_P1_screen_position(int posX, int posY)
        {
            OutputIndented($"Moving the application window to position: ({posX},{posY})");
            _application.SetMainWindowPosition(posX, posY);
        }


        [When(@"I resize the application window to a new (.*) and (.*)")]
        public void When_I_resize_the_application_window_to_a_new_P0_and_P1(int expectedWidth, int expectedHeight)
        {
            OutputIndented($"Moving the application window to position: ({expectedWidth},{expectedHeight})");
            _application.SetMainWindowSize(expectedWidth, expectedHeight);
        }


        [Then(@"I expect the window's new position to be \((.*), (.*)\)")]
        public void Then_I_expect_the_windows_new_position_to_be(int expectedPosX, int expectedPosY)
        {
            OutputIndented($"The application window's EXPECTED position: ({expectedPosX},{expectedPosY})");
            var actualPosition = _application.GetMainWindowPosition();
            OutputIndented($"The application window's ACTUAL position: ({actualPosition.X},{actualPosition.Y})");
            
            using (new AssertionScope())
            {
                _application.Should().BeOfType<FlaUI.Core.Application>();
                actualPosition.X.Should().Be(expectedPosX);
                actualPosition.Y.Should().Be(expectedPosY);
            }
        }


        [Then(@"I expect the window's new size to be \((.*), (.*)\) pixels")]
        public void Then_I_expect_the_windows_new_size_to_be_pixels(int expectedWidth, int expectedHeight)
        {
            var actualSize = _application.GetMainWindowSize();

            using (new AssertionScope())
            {
                _application.Should().BeOfType<FlaUI.Core.Application>();
                actualSize.Width.Should().Be(expectedWidth);
                actualSize.Height.Should().Be(expectedHeight);
            }
        }
    }
}
