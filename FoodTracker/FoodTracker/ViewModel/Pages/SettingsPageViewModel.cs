using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using FoodTracker.Droid.Annotations;
using FoodTracker.PlatformServices.Notifications.Options;

namespace FoodTracker.ViewModel.Pages
{
    public class SettingsPageViewModel :INotifyPropertyChanged
    {
        private IntervalOption _interval;
        private readonly NotifyOption _notify;
        private readonly TimerOption _timer;

        public SettingsPageViewModel(MainFeatures.StartNotificationHandler startNotifyMethod, MainFeatures.StopNotificationHandler stopNotifyMethod)
        {
            _interval = new IntervalOption();

            _stopNotifyMethod = stopNotifyMethod;
            _startNotifyMethod = startNotifyMethod;
        }
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

        public string NotifyName => _notify.Name;

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

        private readonly MainFeatures.StartNotificationHandler _startNotifyMethod;
        private readonly MainFeatures.StopNotificationHandler _stopNotifyMethod;

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
