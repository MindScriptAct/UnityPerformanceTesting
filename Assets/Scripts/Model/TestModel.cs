using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public class TestModel : MonoBehaviour
    {
        public TestData[] BaseDatas;
        public TestData[] TestDatas;

        public int LongestNameCharCount { get; private set; }

        private void Awake()
        {
            Debug.Log($"TestModel - Start..");
            foreach (var item in BaseDatas)
            {
                if (LongestNameCharCount < item.Name.Length)
                {
                    LongestNameCharCount = item.Name.Length;
                }
            }
            foreach (var test in TestDatas)
            {
                if (LongestNameCharCount < test.Name.Length)
                {
                    LongestNameCharCount = test.Name.Length;
                }
            }

        }
    }
}
