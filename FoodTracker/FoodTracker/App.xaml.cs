using FoodTracker.ViewModel;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Xamarin.Forms;

namespace FoodTracker
{
	public partial class App
	{
        public MyApplicationProperties MyProperties;

	    public static ISettings AppSettings => CrossSettings.Current;

        public App ()
		{
			InitializeComponent();
            MyProperties = new MyApplicationProperties();

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
