using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FoodTracker.ViewModel;

namespace FoodTracker.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        private readonly Settings _settings;

        public SettingsPage(ref Settings settings)
        {
            InitializeComponent();

            _settings = settings;

            BindingContext = settings;
        }

        protected override async void OnDisappearing()
        {
            await MyApplicationProperties.SaveProperties();
            base.OnDisappearing();
        }
    }
}
