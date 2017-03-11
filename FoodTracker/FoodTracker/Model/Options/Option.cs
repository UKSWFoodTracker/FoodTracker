using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.Model
{
    /*This class holds data for single setting witch is passing to list in View.SettingsPage*/
    abstract class Option
    {
        public Option(string name, string pageToOpen)
        {
            Name = name;
            PageToOpen = pageToOpen;
        }

        //properties uses to display value
        public string Name { get; private set; }
        public abstract string Value { get; set; }
        
        public string PageToOpen { get; private set; }
    }
}
