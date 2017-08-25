using FoodTracker.Model;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTracker.PlatformServices.Notifications;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private MainFeatures mainFeatures;

        public SettingsPage()
        {
            InitializeComponent();

            mainFeatures = new MainFeatures();

            BindingContext = mainFeatures.settings;
        }

        protected async override void OnDisappearing()
        {
            await mainFeatures.SaveProperties();
            base.OnDisappearing();
        }

        private void StopNotification(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            mainFeatures.notifyManager.StopNotification();
        }

        private void btnNotifyTest_Clicked(object sender, EventArgs e)
        {
            mainFeatures.notifyManager.StartNotification();
        }
    }
}
