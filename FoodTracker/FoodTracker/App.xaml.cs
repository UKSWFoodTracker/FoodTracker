using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FoodTracker.ViewModel;

using Xamarin.Forms;

namespace FoodTracker
{
	public partial class App : Application
    {
        public class MyApplicationProperties
        {
            //<summary>
            //<para> Thanks to this class I'm able to have cleaner more maintainable code in SettingsPage class. 
            //<para> Also this class can be reached from every place of application because is nested in App class. 
            //</summary>
            // Key which is stored in Application.Current.Properties dictionary
            private readonly string SettingsViewModelKey = "SettingsViewModel";
            public SettingsViewModel SettingsViewModel
            {
                get
                {
                    if (Current.Properties.ContainsKey(SettingsViewModelKey))
                    {
                        return (SettingsViewModel)Current.Properties[SettingsViewModelKey];
                    }
                    Current.Properties[SettingsViewModelKey] = new SettingsViewModel();
                    return Current.Properties[SettingsViewModelKey] as SettingsViewModel;
                }
                set
                {
                    Current.Properties[SettingsViewModelKey] = value;
                }
            }
        }
        public MyApplicationProperties myProperties;

        public App ()
		{
			InitializeComponent();
            myProperties = new MyApplicationProperties();

            MainPage = new NavigationPage(new View.MainPage())
            {
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
