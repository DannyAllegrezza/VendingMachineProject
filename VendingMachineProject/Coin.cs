using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    public class Coin
    {
        public Coin(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }
}
