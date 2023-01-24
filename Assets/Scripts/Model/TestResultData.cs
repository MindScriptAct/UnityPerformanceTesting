using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    internal class TestResultData
    {
        public string CouplingType { get; internal set; }
        public string TestName { get; internal set; }
        public string RunCount { get; internal set; }
        public long TotalActionCount { get; internal set; }
        public int TotalDuration { get; internal set; }
        public int ActionsPerSec { get; internal set; }
        public double Performance { get; internal set; }
    }
}
