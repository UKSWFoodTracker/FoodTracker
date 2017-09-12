using System;
using FoodTracker.PlatformServices.Notifications.Options;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FoodTracker.ViewModel
{
    //Main class to manage options
    public class Settings :INotifyPropertyChanged
    {
        private UpdateTimerValue _updateTimerValue;
        private readonly IntervalOption _interval;
        private readonly NotifyOption _notify;
        private readonly TimerOption _timer;
        public Settings(StartNotificationHandler startNotifyMethod, StopNotificationHandler stopNotifyMethod)
        {
            //Loading pop-up interval from saved properties
            _interval = new IntervalOption("Pop-ups interval");
            _notify = new NotifyOption("Notification");
            _timer = new TimerOption("Timer", _interval.Value);
            // TODO: ADDING NEW OPTION: creating object

            _stopNotifyMethod = stopNotifyMethod;
            _startNotifyMethod = startNotifyMethod;

            _updateTimerValue = new UpdateTimerValue(OnPropertyChanged);
        }

        // Interval option properties
        public string IntervalName => _interval.Name;

        public string IntervalValueString
        {
            get => String.Format("{0:hh\\:mm\\:ss}", _interval.Value);
            set
            {
                _interval.Value = TimeSpan.Parse(value);
                OnPropertyChanged();
            }
        }
        public TimeSpan IntervalValueTimeSpan
        {
            get => _interval.Value;
            set
            {
                _interval.Value = value;
                OnPropertyChanged();
            }
        }

        public delegate void StartNotificationHandler(int intervalTotalMiliseconds);
        public delegate void StopNotificationHandler();

        private readonly StartNotificationHandler _startNotifyMethod;
        private readonly StopNotificationHandler _stopNotifyMethod;

        public string NotifyName
        {
            get => _notify.Name;
        }

        /// <summary>
        /// Value indicates whether notifications are turn on or down
        /// </summary>
        public bool NotifyValue
        {
            get => _notify.Value;
            set
            {
                _notify.Value = value;

                // Cancel notification request
                if (!value)
                {
                    _stopNotifyMethod();
                }
                else
                {
                    _startNotifyMethod((int) _interval.Value.TotalMilliseconds);
                    _timer.SetTimer();
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Update string in MainPage's "On/Off" button
        /// </summary>
        public string NotifyButton
        {
            get
            {
                OnPropertyChanged();
                return !_notify.Value ? "On" : "Off";
            }
        }

        public string TimerValue {
            get
            {
                if (!NotifyValue)
                {
                    return "Interval off";
                }
                return _timer.HowMuchTimeLeft();
            }
        }
        // TODO: ADDING NEW OPTION: properties

        /// <summary>
        /// Update specified value in form
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
