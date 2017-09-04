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
            _settings = new Settings();
		    _mainFeatures = new MainFeatures(ref _settings);

            lblTime.BindingContext = _mainFeatures.NotifyManager;
        }

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            //pass reference to other class page if you want change displayed page
            //example: await Navigation.PushAsync(new MainPage());
            //don't forget type async before method
            var mealPage = new MealPage();
            await Navigation.PushAsync(mealPage);
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            // Pass data to other page
            var settingsPage = new SettingsPage(ref _settings, ref _mainFeatures);
            await Navigation.PushAsync(settingsPage);
        }
    }
}
