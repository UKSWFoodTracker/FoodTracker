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
		public MainPage ()
		{
			InitializeComponent ();
		}

        private async void btnAddMeal_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MealPage());
        }

        private void btnSettings_Clicked(object sender, EventArgs e)
        {

        }
    }
}
