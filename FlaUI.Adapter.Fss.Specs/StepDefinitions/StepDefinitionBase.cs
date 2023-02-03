using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Adapter.Fss.Specs.StepDefinitions
{
    public class StepDefinitionBase
    {
        public string DecodePathParameter(string path)
        {
            var result = path.Replace(@"\\", @"\");
            return result;
        }
        public void OutputIndented(string message, int indentLevel = 1)
        {
            string indentString = "";
            for(int i = 0; i < indentLevel; i++)
                indentString += "    ";

            var splitLines = message.Split(Environment.NewLine, StringSplitOptions.None);
            
            foreach(var line in splitLines)
                Console.WriteLine($"{indentString}{line}");
        }

        public void Output(string message)
        {
            OutputIndented(message, indentLevel: 0);
        }

    }
}
