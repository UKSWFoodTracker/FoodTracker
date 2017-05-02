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
        private Settings settings;

        public SettingsViewModel()
        {
            settings = new Settings();
        }

        // Interval option properties
        public string IntervalName
        {
            get => settings.IntervalName;
        }
        public string IntervalValue
        {
            get => settings.IntervalValue;
            set
            {
                settings.IntervalValue = value;
                OnPropertyChanged("IntervalValue");
            }
        }
        // TODO: ADDING NEW OPTION: properties for ModelView

        //Data update method
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
