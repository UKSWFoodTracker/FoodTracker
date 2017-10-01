using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class NotifyOption : Option<bool>
    {
        public NotifyOption() : base("Notifications")
        {
            GetFromMyProperties();
        }

        protected sealed override bool GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.MyProperties.NotifyState;
        }

        protected override void SaveToMyProperties(bool value)
        {
            var app = Application.Current as App;
            app.MyProperties.NotifyState = value;
        }
    }
}
