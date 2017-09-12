using System;
using FoodTracker.ViewModel;
using Xamarin.Forms;

namespace FoodTracker.View
{
	public partial class MainPage : ContentPage
	{
        private MainFeatures _mainFeatures;
	    private Settings _settings;

        public MainPage ()
		{
			InitializeComponent ();
		    _mainFeatures = new MainFeatures();
            _settings = new Settings(_mainFeatures.StartNotification, _mainFeatures.StopNotification);

            timerDisplay.BindingContext = _settings;
		    notifySwitcher.BindingContext = _settings;
		}

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            //pass reference to other class page if you want change displayed page
            var mealPage = new MealPage();
            await Navigation.PushAsync(mealPage);
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            // Pass data to other page
            var settingsPage = new SettingsPage(ref _settings);
            await Navigation.PushAsync(settingsPage);
        }

	    private void BtnNotifyButton_OnClicked(object sender, EventArgs e)
	    {
	        _settings.NotifyValue = !_settings.NotifyValue;
	    }
	}
}
