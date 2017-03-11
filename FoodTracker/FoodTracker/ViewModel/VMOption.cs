using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.ViewModel
{
    public class VMOption
    {
        public VMOption(string name, string value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; private set; }
        public string Value { get; private set; }
    }
}
