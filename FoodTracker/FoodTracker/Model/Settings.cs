using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model.Options;
using System.ComponentModel;
using Xamarin.Forms;

namespace FoodTracker.Model
{
    //Main class to manage options
    class Settings
    {
        public Settings(TimeSpan alarmInterval)
        {
            interval = new IntervalOption("Pop-ups interval", alarmInterval);
            // TODO: ADDING NEW OPTION: creating object
        }
        // Interval option properties
        private IntervalOption interval;
        public string IntervalName
        {
            get => interval.Name;
        }
        public TimeSpan IntervalValue
        {
            get => interval.TimePeriod;
            set
            {
                interval.TimePeriod = value;
                var app = Application.Current as App;
                app.myProperties.IntervalTimeSpan = value;
                OnPropertyChanged("IntervalValue");
            }
        }
        // TODO: ADDING NEW OPTION: properties

        //Form update method and event
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
