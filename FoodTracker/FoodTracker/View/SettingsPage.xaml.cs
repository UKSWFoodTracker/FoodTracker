using FoodTracker.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private SettingsViewModel settingsViewModel;

        public SettingsPage()
        {
            InitializeComponent();

            var app = Application.Current as App;
            settingsViewModel = app.myProperties.SettingsViewModel;
            BindingContext = settingsViewModel;
        }

        protected async override void OnDisappearing()
        {
            await Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }
    }
}
