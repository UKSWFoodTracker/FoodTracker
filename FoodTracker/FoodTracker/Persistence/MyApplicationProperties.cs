﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.ViewModel
{

    //TODO: This class should not be in ViewModel layer
    /// <summary>
    /// It's usefull for gather all application properies in one class. 
    /// Thanks to this class I'm able to have cleaner more maintainable code in SettingsPage class. 
    /// Also this class can be easily reached from every place of application because is nested in App class.
    /// </summary>
    public class MyApplicationProperties
    {
        // Key which is stored in Application.Current.Properties dictionary
        private readonly string IntervalTimeSpanKey = "IntervalTimeSpan";
        private readonly string NotifyKey = "NotifyState";
        private readonly string VibrateKey = "VibrateState";
        //TODO: ADDING NEW OPTION: key & application properties
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
        public bool NotifyState
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(NotifyKey))
                {
                    return (bool)Application.Current.Properties[NotifyKey];
                }
                // TODO: Return TimeSpan object from memory's device
                Application.Current.Properties[NotifyKey] = true;
                return (bool)Application.Current.Properties[NotifyKey];
            }
            set
            {
                Application.Current.Properties[NotifyKey] = value;
            }
        }
        public bool VibrateState
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(VibrateKey))
                {
                    return (bool)Application.Current.Properties[VibrateKey];
                }
                // TODO: Return TimeSpan object from memory's device
                Application.Current.Properties[VibrateKey] = true;
                return (bool)Application.Current.Properties[VibrateKey];
            }
            set
            {
                Application.Current.Properties[VibrateKey] = value;
            }
        }
    }
}