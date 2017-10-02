using System;
using FoodTracker.ViewModel;
using FoodTracker.ViewModel.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTracker.View
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
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
		    pause.BindingContext = _mainPageViewModel;
		}

        private async void AddMeal_OnClicked(object sender, EventArgs e)
        {
            // Pass reference to other class page if you want change displayed page
            var mealPage = new MealPage();
            await Navigation.PushAsync(mealPage);
        }

        private async void Settings_OnClicked(object sender, EventArgs e)
        {
            // Pass data to other page
            var settingsPageVm = new SettingsPageViewModel(_mainFeatures.StartNotification, _mainFeatures.StopNotification);
            var settingsPage = new SettingsPage(settingsPageVm);
            await Navigation.PushAsync(settingsPage);
        }

	    private void Pause_OnClicked(object sender, EventArgs e)
	    {
	        _mainPageViewModel.ChangeTimerStatus();
	    }

	    protected override async void OnDisappearing()
	    {
	        await MyApplicationProperties.SaveProperties();
	        base.OnDisappearing();
	    }
    }
}
