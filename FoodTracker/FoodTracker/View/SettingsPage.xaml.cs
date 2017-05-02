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
        private SettingsViewModel vmsets;

        public SettingsPage ()
		{
			InitializeComponent ();

            vmsets = new ViewModel.SettingsViewModel();
            //listView.ItemsSource = vmsets.VMOptions;
		}

        private async void listView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //OptionViewModel opt = e.Item as OptionViewModel;
            //Page toDisplay = vmsets.GetPageToDisplay(opt);
            //if (toDisplay != null)
            //{
            //    await Navigation.PushAsync(toDisplay);
            //}
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //listView.SelectedItem = null;
        }
    }
}
