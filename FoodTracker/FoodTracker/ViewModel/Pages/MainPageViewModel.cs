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
        private readonly IntervalOption _interval;
        private readonly NotifyOption _notify;
        public readonly Timer _timer;

        public MainPageViewModel(MainFeatures.StartNotificationHandler startNotifyMethod, MainFeatures.StopNotificationHandler stopNotifyMethod)
        {
            _interval = new IntervalOption();
            _notify = new NotifyOption();
            _timer = new Timer(_interval);

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

                //if (!value)
                //{
                //    // Cancel notification request
                //    _stopNotifyMethod();
                //}
                //else
                //{
                //    _startNotifyMethod((int)_interval.Value.TotalMilliseconds);
                //    _timer.SetTimer();
                //}

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Method should stop notifications, memory last time
        /// </summary>
        public void ChangeTimerStatus()
        {
            if (NotifyValue)
            {
                PauseTimer();
            }
            else
            {
                ResumeTimer();
            }
            NotifyValue = !NotifyValue;
        }

        private void ResumeTimer()
        {
            _startNotifyMethod((int)_timer.HowMuchTimeLeft().TimeValue.TotalMilliseconds);
            _timer.Resume();
        }

        private void PauseTimer()
        {
            _stopNotifyMethod();
            _timer.Pause();
        }

        /// <summary>
        /// Update string in MainPage's button
        /// </summary>
        public string NotifyButton
        {
            get
            {
                string buttonText;
                switch (_timer.State)
                {
                    case Timer.TimerState.Running:
                        buttonText = "Pause";
                        break;
                    case Timer.TimerState.Stoped:
                        buttonText = "Start";
                        break;
                    case Timer.TimerState.Paused:
                        buttonText = "Resume";
                        break;
                    default:
                        buttonText = "Default";
                        break;
                }
                OnPropertyChanged();
                return buttonText;
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
                return _timer.HowMuchTimeLeft().StringValue;
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
