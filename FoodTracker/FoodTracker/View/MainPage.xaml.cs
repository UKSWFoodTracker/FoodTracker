using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.Model;
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

            lblTime.BindingContext = _mainFeatures.notifyManager;
        }

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            //pass reference to other class page if you want change displayed page
            //example: await Navigation.PushAsync(new MainPage());
            //don't forget type async before method
            await Navigation.PushAsync(new MealPage());
        }

        private async void btnSettings_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
    }
}
