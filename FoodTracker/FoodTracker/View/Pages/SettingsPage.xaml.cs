using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private readonly Settings _settings;
        private readonly MainFeatures _mainFeatures;

        public SettingsPage(ref Settings settings, ref MainFeatures mainFeatures)
        {
            InitializeComponent();

            _settings = settings;
            _mainFeatures = mainFeatures;

            BindingContext = settings;
        }

        protected override async void OnDisappearing()
        {
            await _mainFeatures.SaveProperties();
            base.OnDisappearing();
        }

        //private void StopNotification(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //{
        //    _mainFeatures.NotifyManager.StopNotification();
        //}

        private void btnNotifyTest_Clicked(object sender, EventArgs e)
        {
            int totalMiliseconds = (int) _settings.IntervalValueTimeSpan.TotalMilliseconds;
            _mainFeatures.NotifyManager.StartNotification(totalMiliseconds);
        }
    }
}
