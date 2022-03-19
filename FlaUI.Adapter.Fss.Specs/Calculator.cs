using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlaUI.Adapter.Fss.Specs
{
    public class Calculator
    {
        public float Add(float n1, float n2)
        {
            var result = n1 + n2;
            return result;
        }

        public int Add(int n1, int n2)
        {
            var result = n1 + n2;
            return result;
        }
    }
}
