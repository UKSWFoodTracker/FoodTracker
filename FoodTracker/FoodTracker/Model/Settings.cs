using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model.Options;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace FoodTracker.Model
{
    //Main class to manage options
    class Settings
    {
        public Settings(TimeSpan alarmInterval, bool notifyState, bool vibrateState)
        {
            interval = new IntervalOption("Pop-ups interval", alarmInterval);
            notify = new NotifyOption("Notification", notifyState);
            vibrate = new VibrateOption("Vibrate", vibrateState);
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
                OnPropertyChanged();
            }
        }
        private NotifyOption notify;
        public string NotifyName
        {
            get => notify.Name;
        }
        public bool NotifyValue
        {
            get => notify.OnState;
            set
            {
                notify.OnState = value;
                var app = Application.Current as App;
                app.myProperties.NotifyState = value;
                OnPropertyChanged();
            }
        }
        private VibrateOption vibrate;
        public string VibrateName
        {
            get => vibrate.Name;
        }
        public bool VibrateValue
        {
            get => vibrate.OnState;
            set
            {
                vibrate.OnState = value;
                var app = Application.Current as App;
                app.myProperties.VibrateState = value;
                OnPropertyChanged();
            }
        }
        // TODO: ADDING NEW OPTION: properties

        //Form update method and event
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
