using System;
using System.Runtime.CompilerServices;
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
        private readonly string StartNotifyTimeKey = "StartNotifyTime";
        private readonly string PauseNotifyTimeKey = "PauseNotifyTime";
        private readonly string IntervalTimeSpanKey = "IntervalTime";
        private readonly string NotifyStateKey = "NotifyState";
        private readonly string VibrateStateKey = "VibrateState";
        //TODO: ADDING NEW OPTION: key & application properties
        public Timer.TimerState TimerState
        {
            get => (Timer.TimerState)App.AppSettings.GetValueOrDefault(TimerStateKey, (int)Timer.TimerState.Stoped);
            set => App.AppSettings.AddOrUpdateValue(TimerStateKey, (int)value);
        }
        public TimeSpan PauseNotifyTime
        {
            get => GetValueOrDefault();
            set => App.AppSettings.AddOrUpdateValue(PauseNotifyTimeKey, value.TotalMilliseconds);
        }

        public TimeSpan StartNotifyTime
        {
            get => GetValueOrDefault();
            set => App.AppSettings.AddOrUpdateValue(StartNotifyTimeKey, value.TotalMilliseconds);
        }

        public TimeSpan IntervalTimeSpan
        {
            get => GetValueOrDefault();
            set => App.AppSettings.AddOrUpdateValue(IntervalTimeSpanKey, value.TotalMilliseconds);
        }
        public bool NotifyState
        {
            get => App.AppSettings.GetValueOrDefault(NotifyStateKey, true);
            set => App.AppSettings.AddOrUpdateValue(NotifyStateKey, value);
        }
        public bool VibrateState
        {
            get => App.AppSettings.GetValueOrDefault(VibrateStateKey, true);
            set => App.AppSettings.AddOrUpdateValue(VibrateStateKey, value);
        }

        private TimeSpan GetValueOrDefault([CallerMemberName] string key = null)
        {
            TimeSpan defaultValue = new TimeSpan();
            if (!App.AppSettings.Contains(key))
                return defaultValue;
            long newValue = App.AppSettings.GetValueOrDefault(key, 0);
            return new TimeSpan(newValue);
        }

        public static async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
            throw new NotImplementedException();
        }
    }
}
