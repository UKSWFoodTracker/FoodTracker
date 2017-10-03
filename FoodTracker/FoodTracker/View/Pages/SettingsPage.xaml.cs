using Xamarin.Forms;
using FoodTracker.ViewModel;
using FoodTracker.ViewModel.Pages;

namespace FoodTracker.View
{
    //[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(SettingsPageViewModel settingsPageViewModel)
        {
            InitializeComponent();

            BindingContext = settingsPageViewModel;
        }

        protected override async void OnDisappearing()
        {
            await MyApplicationProperties.SaveProperties();
            base.OnDisappearing();
        }
    }
}
