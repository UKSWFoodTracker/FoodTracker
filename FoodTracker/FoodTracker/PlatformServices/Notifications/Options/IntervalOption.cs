using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class IntervalOption : Option<TimeSpan>
    {
        public IntervalOption(string name) : base(name)
        {
            GetFromMyProperties();
        }

        protected sealed override TimeSpan GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }

        protected override void SaveToMyProperties(TimeSpan value)
        {
            var app = Application.Current as App;
            app.myProperties.IntervalTimeSpan = value;
        }
    }
}
