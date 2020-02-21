using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Namers;

namespace Tennis
{
    public class GoldenMaster : IDisposable
    {
        private readonly StringBuilder _fakeOutput;
        private readonly IDisposable _namer;

        public GoldenMaster()
        {
            _fakeOutput = new StringBuilder();
            Console.SetOut(new StringWriter(_fakeOutput));
            Console.SetIn(new StringReader("a\n"));
        }

        public GoldenMaster(string testName) : this()
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