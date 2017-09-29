using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodTracker.Droid.Annotations;
using FoodTracker.PlatformServices.Notifications.Options;

namespace FoodTracker.ViewModel.Pages
{
    public class SettingsPageViewModel :INotifyPropertyChanged
    {
        private IntervalOption _interval;
        private readonly NotifyOption _notify;
        private readonly Timer _timer;

        public SettingsPageViewModel(MainFeatures.StartNotificationHandler startNotifyMethod, MainFeatures.StopNotificationHandler stopNotifyMethod)
        {
            _interval = new IntervalOption();
            _notify = new NotifyOption();
            _timer = new Timer(_interval);

            _stopNotifyMethod = stopNotifyMethod;
            _startNotifyMethod = startNotifyMethod;
        }
        public string IntervalName => _interval.Name;
        public string IntervalValueString
        {
            get => String.Format("{0:hh\\:mm\\:ss}", _interval.Value);
            set
            {
                if (!TimeSpan.TryParse(value, out TimeSpan timeSpan))
                {
                    return;
                }
                _interval.Value = timeSpan;
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

                if (!value)
                {
                    _stopNotifyMethod();
                    _timer.Pause();
                }
                else
                {
                    _startNotifyMethod((int) _interval.Value.TotalMilliseconds);
                    _timer.Resume();
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
