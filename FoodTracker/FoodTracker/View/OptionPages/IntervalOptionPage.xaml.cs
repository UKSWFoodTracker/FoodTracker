using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTracker.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

namespace FoodTracker.View.OptionPages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IntervalOptionPage : ContentPage
    {
        private VMSettings vmsets;
        string optName;

        public IntervalOptionPage (ViewModel.VMSettings vmsets, string optName)
		{
			InitializeComponent ();

            this.vmsets = vmsets;
            this.optName = optName;
		}

        private async void save_Clicked(object sender, EventArgs e)
        {
            //need to considerate AM and PM
            TimeSpan reduce = new TimeSpan(12, 0, 0);
            if (picker.Time > reduce)
            {
                vmsets.SetValue(optName, (picker.Time - reduce).ToString());
            }
            else
            {
                vmsets.SetValue(optName, picker.Time.ToString());
            }
            await Navigation.PopAsync();
        }
    }
}
