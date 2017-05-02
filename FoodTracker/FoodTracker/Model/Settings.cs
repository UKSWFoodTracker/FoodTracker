using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model.Options;

namespace FoodTracker.Model
{
    //Main class to manage options
    class Settings
    {
        public Settings()
        {
            interval = new IntervalOption("Alarm interval", new TimeSpan(0, 1, 0));
            // TODO: ADDING NEW OPTION: creating object
        }
        // Interval option properties
        private IntervalOption interval;
        public string IntervalName
        {
            get => interval.Name;
        }
        public string IntervalValue
        {
            get => interval.TimePeriod;
            set => interval.TimePeriod = value;
        }
        // TODO: ADDING NEW OPTION: properties
    }
}
