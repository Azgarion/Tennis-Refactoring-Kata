using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Namers;

namespace Tennis.Tests
{
    public class GoldenMasterTest : IDisposable
    {
        private readonly StringBuilder _fakeOutput;
        private readonly IDisposable _namer;

        public GoldenMasterTest()
        {
            _fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(_fakeOutput));
            Console.SetIn(new StringReader("a\n"));
        }

        public GoldenMasterTest(string testName) : this()
        {
            _namer = ApprovalResults.ForScenario(testName);
        }
        
        public void Dispose()
        {
            Approvals.Verify(_fakeOutput.ToString());
            _namer?.Dispose();
        }
    }
}
