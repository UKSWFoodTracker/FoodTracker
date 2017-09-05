using System;
using FoodTracker.PlatformServices.Notifications.Options;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

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
            _timer = new TimerOption("Timer", _interval.TimePeriod);
            // TODO: ADDING NEW OPTION: creating object

            _updateTimerValue = new UpdateTimerValue(OnPropertyChanged);
        }
        private UpdateTimerValue _updateTimerValue;
        // Interval option properties
        private readonly IntervalOption _interval;
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
                if (value)
                {
                    OnStopRequest();
                }
                else
                {
                    OnStartRequest();
                    _timer.SetTimer();
                }

                OnPropertyChanged();
            }
        }

        private readonly VibrateOption _vibrate;
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
        public string TimerValue {
            get
            {
                if (!NotifyValue)
                {
                    return "Interval off";
                }
                return _timer.HowMuchTimeLeft(IntervalValueTimeSpan);
            }
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
        public static event StartRequestHandler StartRequestEvent;
        public delegate void StartRequestHandler(int intervalTotalMiliseconds);
        private void OnStopRequest()
        {
            StartRequestHandler request = StartRequestEvent;
            request?.Invoke((int)IntervalValueTimeSpan.TotalMilliseconds);
        }

        public static event StopRequestHandler StopRequestEvent;
        public delegate void StopRequestHandler();
        private void OnStartRequest()
        {
            StopRequestHandler request = StopRequestEvent;
            request?.Invoke();
        }
    }
}
