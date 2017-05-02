using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.Model
{
    /*This class holds data for single setting witch is passing to list in View.SettingsPage*/
    public abstract class Option
    {
        public Option(string name)
        {
            Name = name;
        }

        //properties uses to display value
        public string Name { get; private set; }
        public abstract string Value { get; set; }
    }
}
