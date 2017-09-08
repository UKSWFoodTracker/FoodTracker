using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class NotifyOption : Option<bool>
    {
        public NotifyOption(string name) : base(name)
        {
            Value = GetFromMyProperties();
        }

        protected sealed override bool GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.NotifyState;
        }
    }
}
