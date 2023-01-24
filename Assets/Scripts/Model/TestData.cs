using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Model
{
    [Serializable]
    public class TestData
    {
        public string Name;
        public TestType Type;

        //public TestActivator TestActivator;
        public GameObject testPrefab;
        public CouplingMode CouplingMode;

        private List<TestRunData> results = new List<TestRunData>();

        private double totalDurationMs = 0;
        private long totalRunCount = 0;

        private string couplingModeName;
        internal int ActionsPerSec { get; private set; }

        public string CouplingModeName
        {
            get
            {
                if (string.IsNullOrEmpty(couplingModeName))
                {
                    couplingModeName = CouplingMode switch
                    {
                        CouplingMode.NotApplies => "...N/A...",
                        CouplingMode.DirectlyCoupled => "COUPLED..",
                        CouplingMode.InverseCoupled => "Inversed.",
                        CouplingMode.Decoupled => "Decoupled",
                        _ => throw new ArgumentOutOfRangeException($"Not handled coupling type : {CouplingMode.NotApplies}")
                    };
                }
                return couplingModeName;
            }
        }

        internal void AddTestResult(double totalDuration, long runCount)
        {
            results.Add(
                new TestRunData()
                {
                    DurationMs = totalDuration,
                    RunCount = runCount
                }
            );
            totalDurationMs += totalDuration;
            totalRunCount += runCount;
            double secCount = totalDurationMs / 1000;
            ActionsPerSec = (int)((secCount != 0) ? totalRunCount / secCount : 0);
            //Debug.LogWarning($" > AddTestResult : td:{totalDuration} rc:{runCount}  tdms:{totalDurationMs}  trc:{totalRunCount} sc:{secCount} aps:{actionsPerSec}");
        }

        internal string GetSumary(TestData controlTest, int longestNameLength)
        {
            double secCount = totalDurationMs / 1000;

            var couplingText = "";
            switch (CouplingMode)
            {
                case CouplingMode.NotApplies:
                    couplingText = "[...N/A...]";
                    break;
                case CouplingMode.DirectlyCoupled:
                    couplingText = "[COUPLED..]";
                    break;
                case CouplingMode.InverseCoupled:
                    couplingText = "[Inversed.]";
                    break;
                case CouplingMode.Decoupled:
                    couplingText = "[Decoupled]";
                    break;
                default: throw new ArgumentOutOfRangeException($"Not handled coupling type : {CouplingMode.NotApplies}");
            }

            string nameAlign = new string(Enumerable.Repeat(' ', longestNameLength - Name.Length).ToArray());

            //Debug.Log($" ... {Name}  {longestNameLength} '{nameAlign}'");

            double effectiveness = 0;
            var controllActionsPerSec = controlTest.ActionsPerSec;
            if (ActionsPerSec > 0 && controllActionsPerSec > 0)
            {
                //var test = (double)(actionsPerSec / controllActionsPerSec) * 100;
                effectiveness = Math.Round((double)(ActionsPerSec / controllActionsPerSec) * 100, 2);
            }

            string allRunSum = "";
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(allRunSum)) allRunSum += "+";
                allRunSum += result.RunCount;
            }

            return
                $"{couplingText}\t{Name}{nameAlign}\t{allRunSum}=\t{totalRunCount}/\t{(int)secCount} s -> \t{(long)ActionsPerSec} a/s     \t{effectiveness} %" +
                "\n";
        }

        public string RunCountSumText
        {
            get
            {
                string allRunSum = "";
                foreach (var result in results)
                {
                    if (!string.IsNullOrEmpty(allRunSum)) allRunSum += "+";
                    allRunSum += result.RunCount;
                }
                return allRunSum;
            }
        }

        public long TotalActionCount => totalRunCount;
        public int TotalDuration => (int)(totalDurationMs / 1000);

        internal double GetPerformanceComparedTo(TestData controlTest)
        {
            var controllActionsPerSec = controlTest.ActionsPerSec;
            if (ActionsPerSec > 0 && controllActionsPerSec > 0)
            {
                return Math.Round((double)ActionsPerSec / controllActionsPerSec * 100, 2);
            }
            return 0;
        }
    }
}