using System;
using System.Threading.Tasks;
using FoodTracker.PlatformServices.Notifications.Options;
using FoodTracker.ViewModel.TimerService;
using Xamarin.Forms;

namespace FoodTracker.ViewModel
{
    /// <summary>
    /// It's usefull for gather all application properies in one class. 
    /// Thanks to this class I'm able to have cleaner more maintainable code in SettingsPage class. 
    /// Also this class can be easily reached from every place of application because is nested in App class.
    /// </summary>
    public class MyApplicationProperties
    {
        // Key which is stored in Application.Current.Properties dictionary
        private readonly string TimerStateKey = "TimerState";
        private readonly string StartNotifyTimeKey = "StartNotifyTimeSpan";
        private readonly string PauseNotifyTimeKey = "PauseNotifyTimeSpan";
        private readonly string IntervalTimeSpanKey = "IntervalTimeSpan";
        private readonly string NotifyStateKey = "NotifyState";
        private readonly string VibrateStateKey = "VibrateState";
        //TODO: ADDING NEW OPTION: key & application properties
        public Timer.TimerState TimerState
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(TimerStateKey))
                {
                    return (Timer.TimerState)Application.Current.Properties[TimerStateKey];
                }
                Application.Current.Properties[TimerStateKey] = Timer.TimerState.Stoped;
                return (Timer.TimerState)Application.Current.Properties[TimerStateKey];
            }
            set
            {
                Application.Current.Properties[TimerStateKey] = value;
            }
        }
        public TimeSpan PauseNotifyTime
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(PauseNotifyTimeKey))
                {
                    return (TimeSpan)Application.Current.Properties[PauseNotifyTimeKey];
                }
                Application.Current.Properties[PauseNotifyTimeKey] = new TimeSpan();
                return (TimeSpan)Application.Current.Properties[PauseNotifyTimeKey];
            }
            set
            {
                Application.Current.Properties[PauseNotifyTimeKey] = value;
            }
        }
        public TimeSpan StartNotifyTime
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(StartNotifyTimeKey))
                {
                    return (TimeSpan)Application.Current.Properties[StartNotifyTimeKey];
                }
                Application.Current.Properties[StartNotifyTimeKey] = new TimeSpan();
                return (TimeSpan)Application.Current.Properties[StartNotifyTimeKey];
            }
            set
            {
                Application.Current.Properties[StartNotifyTimeKey] = value;
            }
        }
        public TimeSpan IntervalTimeSpan
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(IntervalTimeSpanKey))
                {
                    return (TimeSpan)Application.Current.Properties[IntervalTimeSpanKey];
                }
                Application.Current.Properties[IntervalTimeSpanKey] = new TimeSpan();
                return (TimeSpan)Application.Current.Properties[IntervalTimeSpanKey];
            }
            set
            {
                Application.Current.Properties[IntervalTimeSpanKey] = value;
            }
        }
        public bool NotifyState
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(NotifyStateKey))
                {
                    return (bool)Application.Current.Properties[NotifyStateKey];
                }
                Application.Current.Properties[NotifyStateKey] = true;
                return (bool)Application.Current.Properties[NotifyStateKey];
            }
            set
            {
                Application.Current.Properties[NotifyStateKey] = value;
            }
        }
        public bool VibrateState
        {
            get
            {
                if (Application.Current.Properties.ContainsKey(VibrateStateKey))
                {
                    return (bool)Application.Current.Properties[VibrateStateKey];
                }
                Application.Current.Properties[VibrateStateKey] = true;
                return (bool)Application.Current.Properties[VibrateStateKey];
            }
            set
            {
                Application.Current.Properties[VibrateStateKey] = value;
            }
        }
        public static async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
