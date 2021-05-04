using Assets.Scripts.Constants;
using System;
using System.Collections.Generic;
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

        private double totalDurationMs = 0;
        private long totalRunCount = 0;
        private double actionsPerSec;

        internal void AddTestResult(double totalDuration, long runCount)
        {
            results.Add(
                new TestResultData()
                {
                    DurationMs = totalDuration,
                    RunCount = runCount
                }
            );
            totalDurationMs += totalDuration;
            totalRunCount += runCount;
            double secCount = totalDurationMs / 1000;
            actionsPerSec = (secCount != 0) ? totalRunCount / secCount : 0;
        }

        internal string GetSumary(TestData controlTest)
        {
            double secCount = totalDurationMs / 1000;

            var couplingText = "";
            switch (CouplingMode)
            {
                case CouplingMode.DirectlyCoupled: couplingText = "[COUPLED.]"; break;
                case CouplingMode.InverseCoupled: couplingText = "[Inversed.]"; break;
                case CouplingMode.Decoupled: couplingText = "[Decoupled!]"; break;
            }

            double effectiveness = 0;
            var controllActionsPerSec = controlTest.GetActionsPerSec();
            if (actionsPerSec > 0 && controllActionsPerSec > 0)
            {
                var test = (double)(actionsPerSec / controllActionsPerSec) * 100;
                effectiveness = Math.Round((double)(actionsPerSec / controllActionsPerSec) * 100, 2);
            }

            return $"{couplingText} '{Name}' time:{(int)secCount}s count:{totalRunCount} ->  Actions/Sec : {(long)actionsPerSec}         {effectiveness}%" + "\n";
        }

        private double GetActionsPerSec()
        {
            return actionsPerSec;
        }
    }
}
