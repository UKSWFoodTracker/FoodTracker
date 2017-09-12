using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage(ref Settings settings)
        {
            InitializeComponent();

            BindingContext = settings;
        }

        protected override async void OnDisappearing()
        {
            await MyApplicationProperties.SaveProperties();
            base.OnDisappearing();
        }
    }
}
