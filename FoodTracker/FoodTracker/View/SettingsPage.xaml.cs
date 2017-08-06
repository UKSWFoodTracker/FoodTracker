using FoodTracker.Model.AlarmClock;
using FoodTracker.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private Settings settings;

        public SettingsPage()
        {
            InitializeComponent();

            //Loading pop-up interval from saved properties
            TimeSpan alarmInterval = getInterval();
            bool notifyState = getNotifyState();
            bool vibrateState = getVibrateState();
            settings = new Settings(alarmInterval, notifyState, vibrateState);
            //TODO: ADDING NEW OPTION: Update 
            BindingContext = settings;
        }

        private bool getVibrateState()
        {
            var app = Application.Current as App;
            return app.myProperties.VibrateState;
        }

        private bool getNotifyState()
        {
            var app = Application.Current as App;
            return app.myProperties.NotifyState;
        }

        protected async override void OnDisappearing()
        {
            await Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }

        private void btnNotifyTest_Clicked(object sender, EventArgs e)
        {
            TimeSpan alarmInterval = getInterval();
            AlarmClockManager.ShowNotification(false, (int)alarmInterval.TotalMilliseconds);
        }

        private TimeSpan getInterval()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }
        //TODO: ADDING NEW OPTION: return options' value from application properties
    }
}
