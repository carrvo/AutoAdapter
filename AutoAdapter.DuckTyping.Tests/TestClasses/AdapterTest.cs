using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter.Tests
{
    public class AdapterTest
    {
        public Boolean Called { get; private set; } = false;
        public void TestMethod()
        {
            Called = true;
        }
    }
}
