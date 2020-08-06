using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachineProject
{
    public class Snack
    {
        public Snack(string snackName)
        {
            Name = snackName;
        }
        public string Name { get; set; }
    }
}
