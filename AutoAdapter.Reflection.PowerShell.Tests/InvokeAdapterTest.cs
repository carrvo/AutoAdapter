using AutoAdapter.Tests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace AutoAdapter.PowerShell.Tests
{
    [Cmdlet(VerbsLifecycle.Invoke, "Test")]
    public class InvokeAdapterTest : Cmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipeline = true)]
        public IAdapterTest InputObject
        {
            get; set;
        }

        protected override void ProcessRecord()
        {
            InputObject.TestMethod();
        }
    }
}
