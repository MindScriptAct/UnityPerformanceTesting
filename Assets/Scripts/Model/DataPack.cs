using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Model
{
    public struct DataPack
    {
        public int Nr;
        public string Text;
        public float Nr2;
        public Vector2 Vector2;
        public MyData MyData;

        public DataPack(int nr, string text, float nr2, Vector2 vector2, MyData myData)
        {
            Nr = nr;
            Text = text;
            Nr2 = nr2;
            Vector2 = vector2;
            MyData = myData;
        }
    }
}
