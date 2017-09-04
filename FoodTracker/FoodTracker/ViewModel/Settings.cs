using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.PlatformServices.Notifications.Options;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;

namespace FoodTracker.ViewModel
{
    //Main class to manage options
    public class Settings :INotifyPropertyChanged
    {
        public Settings()
        {
            //Loading pop-up interval from saved properties
            _interval = new IntervalOption("Pop-ups interval", getInterval());
            _notify = new NotifyOption("Notification", getNotifyState());
            _vibrate = new VibrateOption("Vibrate", getVibrateState());
            _timer = new TimerOption("Timer");
            // TODO: ADDING NEW OPTION: creating object

            _updateTimerThread = new UpdateTimerThread(OnPropertyChanged);
        }
        private UpdateTimerThread _updateTimerThread;
        // Interval option properties
        private IntervalOption _interval;
        public string IntervalName
        {
            get => _interval.Name;
        }
        public string IntervalValueString
        {
            get => String.Format("{0:hh\\:mm\\:ss}", _interval.TimePeriod);
            set
            {
                TimeSpan timeValue = TimeSpan.Parse(value);
                _interval.TimePeriod = timeValue;
                var app = Application.Current as App;
                app.myProperties.IntervalTimeSpan = timeValue;
                OnPropertyChanged();
            }
        }
        public TimeSpan IntervalValueTimeSpan
        {
            get => _interval.TimePeriod;
            set
            {
                TimeSpan timeValue = value;
                _interval.TimePeriod = timeValue;
                var app = Application.Current as App;
                app.myProperties.IntervalTimeSpan = timeValue;
                OnPropertyChanged();
            }
        }
        private NotifyOption _notify;
        public string NotifyName
        {
            get => _notify.Name;
        }
        public bool NotifyValue
        {
            get => _notify.OnState;
            set
            {
                _notify.OnState = value;
                // Saving in app properties
                var app = Application.Current as App;
                app.myProperties.NotifyState = value;
                // Cancel notification request
                OnStopRequest();

                OnPropertyChanged();
            }
        }
        private VibrateOption _vibrate;
        public string VibrateName
        {
            get => _vibrate.Name;
        }
        public bool VibrateValue
        {
            get => _vibrate.OnState;
            set
            {
                _vibrate.OnState = value;
                var app = Application.Current as App;
                app.myProperties.VibrateState = value;
                OnPropertyChanged();
            }
        }
        private readonly TimerOption _timer;
        public string TimerValue => _timer.HowMuchTimeLeft(IntervalValueTimeSpan);

        public void SetTimer()
        {
            _timer.SetTimer(_interval.TimePeriod);
        }
        // TODO: ADDING NEW OPTION: properties

        private TimeSpan getInterval()
        {
            var app = Application.Current as App;
            return app.myProperties.IntervalTimeSpan;
        }

        private bool getVibrateState()
        {
            var app = Application.Current as App;
            return app.myProperties.VibrateState;
        }

        private bool getNotifyState()
        {
            var app = Application.Current as App;
            return app.myProperties.NotifyState;
        }
        //TODO: ADDING NEW OPTION: return options' value from application properties

        /// <summary>
        /// Update specified value in form
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        /// <summary>
        /// Request to stop notifications
        /// </summary>
        public event StopRequestHandler StopRequestEvent;
        public delegate void StopRequestHandler();
        private void OnStopRequest()
        {
            StopRequestHandler stopRequest = StopRequestEvent;
            stopRequest?.Invoke();
        }
    }
}
