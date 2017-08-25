using FoodTracker.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace FoodTracker.View
{
	public partial class MainPage : ContentPage
	{
        MainFeatures mainFeatures;

        public MainPage ()
		{
			InitializeComponent ();
            mainFeatures = new MainFeatures();
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
