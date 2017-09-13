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
            GetFromMyProperties();
        }

        protected sealed override bool GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.VibrateState;
        }

        protected override void SaveToMyProperties()
        {
            var app = Application.Current as App;
            app.myProperties.VibrateState = Value;
        }
    }
}
