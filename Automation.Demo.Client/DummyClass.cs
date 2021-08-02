using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Demo.Client
{
    public class DummyClass
    {
        public bool IsValidName(string name)
        {
            var result = false;
            if (!string.IsNullOrWhiteSpace(name)) result = true;
            return result;
        }
    }
}
