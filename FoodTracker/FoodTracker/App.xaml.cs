using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Content;
using FoodTracker.ViewModel;

using Xamarin.Forms;

namespace FoodTracker
{
	public partial class App : Application
    {
        public MyApplicationProperties myProperties;
        
        public App ()
		{
			InitializeComponent();
            myProperties = new MyApplicationProperties();

            MainPage = new NavigationPage(new View.MainPage())
            {
                // TODO: NAVIGATION_PAGE COLOR
                BarBackgroundColor = Color.Gray,
                BarTextColor = Color.White,
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
