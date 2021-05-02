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
        public TestActivator TestActivator;

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

            //testProgress.text = $"DONE : '{testLabel}'";
            //
            //double secconds = totalDuration / 1000;
            //double actionsPerSeconds = runCount / secconds;


            return $"'{Name}' time:{(int)secCount}s count:{totalRunCount} ->  Actions/Sec : {(long)actionsPerSeconds}" + "\n";
        }
    }
}
