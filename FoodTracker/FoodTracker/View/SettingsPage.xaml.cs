using FoodTracker.Model.AlarmClock;
using FoodTracker.ViewModel;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel settingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();

            TimeSpan alarmInterval = getInterval();
            settingsViewModel = new SettingsViewModel(alarmInterval);
            BindingContext = settingsViewModel;
        }

        protected async override void OnDisappearing()
        {
            await Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }

        private void btnNotifyTest_Clicked(object sender, EventArgs e)
        {
            TimeSpan alarmInterval = getInterval();
            AlarmClockManager.OnNotificationEvent(true, alarmInterval);
        }

        private TimeSpan getInterval()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }
    }
}
