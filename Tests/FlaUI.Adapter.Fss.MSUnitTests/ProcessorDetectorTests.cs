using FlaUI.Adapter.Fss.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlaUI.Adapter.Fss.MSUnitTests
{
    [TestClass]
    public class ProcessorDetectorTests
    {
        [TestMethod]
        public void Can_detect_a_running_notepad_process()
        {
            // Given - a process detector
            //         and three instances of notepad running
            var sut = new ProcessDetector();

            // When - I check if the notepad process is running
            var isNotepadInstanceRunning = sut.IsProcessRunning("Notepad");
            Console.WriteLine($"sut.IsProcessRunning(\"Notepad\"): {sut.IsProcessRunning("Notepad")}");

            // Then - The process is running
            using (new AssertionScope())
            {
                isNotepadInstanceRunning.Should().BeTrue();
            }
        }

        [TestMethod]
        public void Can_detect_all_running_notepad_processes()
        {
            // Given - a process detector
            //         and three instances of notepad running
            var sut = new ProcessDetector();

            // When - I check if the notepad process is running
            var notepadInstancesRunning = sut.GetRunningProcessByName("Notepad");
            Console.WriteLine($"sut.GetRunningProcessByName(\"Notepad\"): Count: {sut.GetRunningProcessByName("Notepad").Count}");

            // Then - The process is running
            using (new AssertionScope())
            {
                notepadInstancesRunning.Should().HaveCount(3);
            }
        }

        [TestMethod]
        public void Can_wait_for_a_running_notepad_process()
        {
            // Given - a process detector
            //         and three instances of notepad running
            var sut = new ProcessDetector();

            // When - I check if the notepad process is running
            var notepadInstancesRunning = sut.WaitForProcess("Notepad");
            Console.WriteLine($"sut.WaitForProcess(\"Notepad\"): Result: {sut.WaitForProcess("Notepad")}");

            // Then - The process is running
            using (new AssertionScope())
            {
                notepadInstancesRunning.Should().BeTrue();
            }
        }
    }
}
                
                //// Then - I list the processes
                //var processNames = Process.GetProcesses().Select(p => p.ProcessName);
                //Console.WriteLine();
                //Console.WriteLine("Process List:");
                //foreach (var processName in processNames)
                //{
                //    Console.WriteLine($"\t{processName}");
                //}