using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (Application.Current.Properties.ContainsKey("SettingsViewModel"))
            {
                settingsViewModel = Application.Current.Properties["SettingsViewModel"] as SettingsViewModel;
            }
            else
            {
                settingsViewModel = new SettingsViewModel();
            }
            BindingContext = settingsViewModel;
        }

        protected override void OnDisappearing()
        {
            Application.Current.Properties["SettingsViewModel"] = settingsViewModel;
            Application.Current.SavePropertiesAsync();
            base.OnDisappearing();
        }
    }
}
