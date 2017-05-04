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

        // TODO: ADDING NEW OPTION: arguments for constructor
        public SettingsViewModel(TimeSpan alarmInterval)
        {
            settings = new Settings(alarmInterval);
        }

        // TODO: ADDING NEW OPTION: properties for ModelView
        // Interval option properties
        public string IntervalName
        {
            get => settings.IntervalName;
        }
        public TimeSpan IntervalValue
        {
            get => settings.IntervalValue;
            set
            {
                settings.IntervalValue = value;
                var app = Application.Current as App;
                app.myProperties.IntervalTimeSpan = value;
                OnPropertyChanged("IntervalValue");
            }
        }

        //Data update method
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
