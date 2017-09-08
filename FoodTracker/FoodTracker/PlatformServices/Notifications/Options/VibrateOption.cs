using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    public class VibrateOption : Option<bool>
    {
        public VibrateOption(string name) : base(name)
        {
            Value = GetFromMyProperties();
        }

        protected sealed override bool GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.VibrateState;
        }
    }
}
