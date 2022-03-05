using FlaUI.Adapter.Fss.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlaUI.Adapter.Fss.MSUnitTests
{
    [TestClass]
    public class SpecificProcessorDetectorTests
    {
        [TestMethod]
        public void Can_detect_a_running_notepad_process()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var sut = new SpecificProcessDetector(new ProcessDetector(), "NotePad");

            // When - I check if the notepad process is running
            var isNotepadInstanceRunning = sut.IsProcessRunning();
            Console.WriteLine($"sut.IsProcessRunning(): {sut.IsProcessRunning()}");

            // Then - The process is running
            using (new AssertionScope())
            {
                isNotepadInstanceRunning.Should().BeTrue();
            }
        }

        [TestMethod]
        public void Can_detect_all_running_notepad_processes()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var sut = new SpecificProcessDetector(new ProcessDetector(), "NotePad");

            // When - I check if the notepad process is running
            var notepadInstancesRunning = sut.GetRunningProcesses();
            Console.WriteLine($"sut.GetRunningProcessByName(): Count: {sut.GetRunningProcesses().Count}");

            // Then - The process is running
            using (new AssertionScope())
            {
                notepadInstancesRunning.Should().HaveCount(3);
            }
        }

        [TestMethod]
        public void Can_wait_for_a_running_notepad_process()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var sut = new SpecificProcessDetector(new ProcessDetector(), "NotePad");

            // When - I check if the notepad process is running
            var notepadInstancesRunning = sut.WaitForProcess();
            Console.WriteLine($"sut.WaitForProcess(\"Notepad\"): Result: {sut.WaitForProcess()}");

            // Then - The process is running
            using (new AssertionScope())
            {
                notepadInstancesRunning.Should().BeTrue();
            }
        }


        [TestMethod]
        public void Can_wait_for_a_running_msedge_process()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var fqn = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            var sut = new SpecificProcessDetector(new ProcessDetector(), "msedge");

            // When - I check if the notepad process is running
            var notepadInstancesRunning = sut.WaitForProcess();
            Console.WriteLine($"sut.WaitForProcess(\"msedge\"): Result: {sut.WaitForProcess()}");

            // Then - The process is running
            using (new AssertionScope())
            {
                notepadInstancesRunning.Should().BeTrue();
            }
        }
    }
}