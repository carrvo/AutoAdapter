using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter.Tests
{
    [TypeConverter(typeof(AdapterConverter<IAdapterTest>))]
    public interface IAdapterTest
    {
        void TestMethod();
    }
}
