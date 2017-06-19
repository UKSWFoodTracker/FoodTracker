using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModel
{

    //TODO: This class should not be in ViewModel layer
    public class MyApplicationProperties
    {
        //<summary>
        //<para> It's usefull for gather all application properies in one class. 
        //<para> Thanks to this class I'm able to have cleaner more maintainable code in SettingsPage class. 
        //<para> Also this class can be easily reached from every place of application because is nested in App class. 
        //</summary>

        // Key which is stored in Application.Current.Properties dictionary
        private readonly string IntervalTimeSpanKey = "IntervalTimeSpan";
        public TimeSpan IntervalTimeSpan
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(IntervalTimeSpanKey))
                {
                    return (TimeSpan)Application.Current.Properties[IntervalTimeSpanKey];
                }
                // TODO: Return TimeSpan object from memory's device
                Application.Current.Properties[IntervalTimeSpanKey] = new TimeSpan();
                return (TimeSpan)Application.Current.Properties[IntervalTimeSpanKey];
            }
            set
            {
                Application.Current.Properties[IntervalTimeSpanKey] = value;
            }
        }
    }
}
