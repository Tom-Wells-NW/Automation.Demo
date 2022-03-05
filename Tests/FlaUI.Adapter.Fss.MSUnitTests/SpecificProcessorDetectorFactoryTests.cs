using FlaUI.Adapter.Fss.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FlaUI.Adapter.Fss.MSUnitTests
{
    [TestClass]
    public class SpecificProcessorDetectorFactoryTests
    {
        [TestMethod]
        public void Can_create_a_specific_process_detector_to_detect_msedge_process()
        {
            // Given - a specific process detector factory
            //         and three instances of notepad running
            var fqn = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            var factory = new SpecificProcessDetectorFactory();
            var sut = factory.Create(fqn);

            // When - I check if the notepad process is running
            var isMsEdgeInstanceRunning = sut.IsProcessRunning();
            Console.WriteLine($"sut.IsProcessRunning(): {sut.IsProcessRunning()}");

            // Then - The process is running
            using (new AssertionScope())
            {
                isMsEdgeInstanceRunning.Should().BeTrue();
            }
        }

        [TestMethod]
        public void Can_create_a_specific_process_detector_to_detect_all_msedge_processes()
        {
            // Given - a specific process detector factory
            //         and three instances of notepad running
            var fqn = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe";
            var factory = new SpecificProcessDetectorFactory();
            var sut = factory.Create(fqn);

            // When - I check if the notepad process is running
            var msEdgeInstancesRunning = sut.GetRunningProcesses();
            Console.WriteLine($"sut.GetRunningProcessByName(): Count: {sut.GetRunningProcesses().Count}");

            // Then - The process is running
            using (new AssertionScope())
            {
                msEdgeInstancesRunning.Should().HaveCountGreaterOrEqualTo(3);
            }
        }

        [TestMethod]
        public void Can_create_a_specific_process_detector_to_wait_for_a_running_notepad_process()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var fqn = @"C:\Windows\NotePad.exe";
            var factory = new SpecificProcessDetectorFactory();
            var sut = factory.Create(fqn);

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
        public void Can_create_a_specific_process_detector_to_wait_for_a_running_msedge_process()
        {
            // Given - a specific process detector
            //         and three instances of notepad running
            var fqn = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"; 
            var factory = new SpecificProcessDetectorFactory();
            var sut = factory.Create(fqn);

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