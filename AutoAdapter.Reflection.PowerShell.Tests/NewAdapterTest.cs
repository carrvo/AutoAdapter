using AutoAdapter.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter.PowerShell.Tests
{
    [Cmdlet(VerbsCommon.New, "Test")]
    public class NewAdapterTest : Cmdlet
    {
        protected override void ProcessRecord()
        {
            WriteObject(new AdapterTest());
        }
    }
}
