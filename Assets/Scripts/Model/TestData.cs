using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class TestData
    {
        public string Name;
        //public TestActivator TestActivator;
        public GameObject testPrefab;
        public CouplingMode CouplingMode;

        private List<TestResultData> results = new List<TestResultData>();
        internal void AddTestResult(double totalDuration, long runCount)
        {
            results.Add(
                new TestResultData()
                {
                    DurationMs = totalDuration,
                    RunCount = runCount
                }
            );
        }

        internal string GetSumary()
        {
            double totalDuration = 0;
            long totalRunCount = 0;
            foreach (var result in results)
            {
                totalDuration += result.DurationMs;
                totalRunCount += result.RunCount;

            }
            double secCount = totalDuration / 1000;

            var actionsPerSeconds = (secCount != 0) ? totalRunCount / secCount : 0;

            var couplingText = "";
            switch (CouplingMode)
            {
                case CouplingMode.DirectlyCoupled: couplingText = "[COUPLED.]"; break;
                case CouplingMode.InverseCoupled: couplingText = "[Inversed.]"; break;
                case CouplingMode.Decoupled: couplingText = "[Decoupled!]"; break;
            }

            return $"{couplingText} '{Name}' time:{(int)secCount}s count:{totalRunCount} ->  Actions/Sec : {(long)actionsPerSeconds}" + "\n";
        }
    }
}
