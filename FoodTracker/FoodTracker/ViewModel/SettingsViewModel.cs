using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using Xamarin.Forms;
using System.ComponentModel;

namespace FoodTracker.ViewModel
{
    public class SettingsViewModel
    {
        private Settings sets;
        // list to display in SettingsPage
        private List<OptionViewModel> optionsViewModel;
        // ...property
        public List<OptionViewModel> OptionsViewModel { get { return optionsViewModel; } }

        public SettingsViewModel()
        {
            sets = new Model.Settings();
            optionsViewModel = new List<OptionViewModel>();
            foreach (Option item in sets.GetOptions)
            {
                optionsViewModel.Add(new OptionViewModel(item));
            }
        }

        public void SetValue(string optName, string optValue)
        {
            foreach (OptionViewModel item in optionsViewModel)
            {
                if (item.Name == optName)
                {
                    item.Value = optValue;
                }
            }
        }
    }
}
