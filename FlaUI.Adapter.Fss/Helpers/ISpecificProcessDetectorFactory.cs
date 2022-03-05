using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Adapter.Fss.Helpers
{
    public interface ISpecificProcessDetectorFactory
    {
        ISpecificProcessDetector Create(string fullyQualifiedFileName);

        ISpecificProcessDetector Create(IProcessDetector processDetector, string processName);
    }
}
