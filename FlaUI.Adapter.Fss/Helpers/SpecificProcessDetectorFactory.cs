using System.IO;

namespace FlaUI.Adapter.Fss.Helpers
{
    public class SpecificProcessDetectorFactory : ISpecificProcessDetectorFactory
    {
        public ISpecificProcessDetector Create(string fullyQualifiedFileName)
        {
            var processName = GetProcessName(fullyQualifiedFileName);
            var result = Create(new ProcessDetector(), processName);
            return result;
        }

        private string GetProcessName(string fullyQualifiedFileName)
        {
            var result = Path.GetFileNameWithoutExtension(fullyQualifiedFileName);
            return result;
        }

        public ISpecificProcessDetector Create(IProcessDetector processDetector, string processName)
        {
            var result = new SpecificProcessDetector(processDetector, processName);
            return result;
        }
    }
}
