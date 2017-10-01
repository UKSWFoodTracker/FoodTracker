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
            return app.MyProperties.VibrateState;
        }

        protected override void SaveToMyProperties(bool value)
        {
            var app = Application.Current as App;
            app.MyProperties.VibrateState = value;
        }
    }
}
