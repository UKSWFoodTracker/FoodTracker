using System;
using FoodTracker.ViewModel;
using Xamarin.Forms;
using FoodTracker.ViewModel.Pages;

namespace FoodTracker.View
{
	public partial class MainPage : ContentPage
	{
	    private readonly MainPageViewModel _mainPageViewModel;
	    private readonly MainFeatures _mainFeatures;

        public MainPage ()
		{
			InitializeComponent ();

		    _mainFeatures = new MainFeatures();
            _mainPageViewModel = new MainPageViewModel(_mainFeatures.StartNotification, _mainFeatures.StopNotification);

            timerDisplay.BindingContext = _mainPageViewModel;
		    notifySwitcher.BindingContext = _mainPageViewModel;
		}

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            // Pass reference to other class page if you want change displayed page
            var mealPage = new MealPage();
            await Navigation.PushAsync(mealPage);
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            // Pass data to other page
            var settingsPageVM = new SettingsPageViewModel();
            var settingsPage = new SettingsPage(ref settings);
            await Navigation.PushAsync(settingsPage);
        }

	    private void BtnNotifyButton_OnClicked(object sender, EventArgs e)
	    {
	        _mainPageViewModel.ChangeNotifyState();
	    }
	}
}
