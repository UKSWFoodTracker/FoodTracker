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

            var app = Application.Current as App;
            TimeSpan alarmInterval = app.myProperties.IntervalTimeSpan;
            settingsViewModel = new SettingsViewModel(alarmInterval);
            BindingContext = settingsViewModel;
        }

        protected async override void OnDisappearing()
        {
            await Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }
    }
}
