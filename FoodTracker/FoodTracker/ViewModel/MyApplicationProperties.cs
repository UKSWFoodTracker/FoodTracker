using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModel
{

    public class MyApplicationProperties
    {
        //<summary>
        //<para> Thanks to this class I'm able to have cleaner more maintainable code in SettingsPage class. 
        //<para> Also this class can be reached from every place of application because is nested in App class. 
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
                // TODO: Return TimeSpan object from device's memory
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
