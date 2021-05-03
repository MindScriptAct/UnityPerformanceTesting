using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Model
{
    public struct MyData
    {
        public int Number;
        public string Text;

        public MyData(int number, string text)
        {
            Number = number;
            Text = text;
        }
    }
}
