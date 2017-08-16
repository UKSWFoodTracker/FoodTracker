using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices
{
    /*This class holds data for single setting which is passing to list in View.SettingsPage*/
    public abstract class Option
    {
        public Option(string name)
        {
            Name = name;
        }

        //properties using to display value
        public string Name { get; private set; }
        // Options have to have Value properties but that depends on needed type
    }
}
