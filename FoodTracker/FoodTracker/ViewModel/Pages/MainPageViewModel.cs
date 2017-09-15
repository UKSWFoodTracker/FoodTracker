using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodTracker.Droid.Annotations;
using FoodTracker.PlatformServices.Notifications.Options;

namespace FoodTracker.ViewModel.Pages
{
    /// <summary>
    /// Class is bridge between MainPage and other components
    /// </summary>
    public class MainPageViewModel :INotifyPropertyChanged
    {
        private UpdateTimerValue _updateTimerValue;
        private readonly TimerOption _timer;
        private readonly IntervalOption _interval;
        private readonly NotifyOption _notify;

        public MainPageViewModel(MainFeatures.StartNotificationHandler startNotifyMethod, MainFeatures.StopNotificationHandler stopNotifyMethod)
        {
            _interval = new IntervalOption();
            _timer = new TimerOption(_interval);
            _notify = new NotifyOption();

            _stopNotifyMethod = stopNotifyMethod;
            _startNotifyMethod = startNotifyMethod;

            _updateTimerValue = new UpdateTimerValue(OnPropertyChanged);
        }

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
                    _startNotifyMethod((int)_interval.Value.TotalMilliseconds);
                    _timer.SetTimer();
                }

                OnPropertyChanged();
            }
        }

        public void ChangeNotifyState()
        {
            NotifyValue = !NotifyValue;
        }

        /// <summary>
        /// Update string in MainPage's "On/Off" button
        /// </summary>
        public string NotifyButton
        {
            get
            {
                OnPropertyChanged();
                return !NotifyValue ? "On" : "Off";
            }
        }

        public string TimerValue
        {
            get
            {
                if (!NotifyValue)
                {
                    return "Interval off";
                }
                return _timer.HowMuchTimeLeft();
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
