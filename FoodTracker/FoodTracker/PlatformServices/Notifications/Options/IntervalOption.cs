using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class IntervalOption : Option
    {
        public IntervalOption(string name, TimeSpan value) : base(name)
        {
            this.timePeriod = value;
        }

        private TimeSpan timePeriod;
        public TimeSpan TimePeriod
        {
            get => timePeriod;
            set => timePeriod = value;
        }
    }
}
