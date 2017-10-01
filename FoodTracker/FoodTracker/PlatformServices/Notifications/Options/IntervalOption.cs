using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    public class IntervalOption : Option<TimeSpan>
    {
        public IntervalOption() : base("Interval")
        {
        }

        protected sealed override TimeSpan GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.MyProperties.IntervalTimeSpan;
        }

        protected sealed override void SaveToMyProperties(TimeSpan value)
        {
            var app = Application.Current as App;
            app.MyProperties.IntervalTimeSpan = value;
        }
    }
}
