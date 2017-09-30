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
            get => GetFromDictionary(TimerStateKey, Timer.TimerState.Stoped);
            set => SaveToDictionary(TimerStateKey, value);
        }
        public TimeSpan PauseNotifyTime
        {

            get => GetFromDictionary(PauseNotifyTimeKey, new TimeSpan());
            set => SaveToDictionary(PauseNotifyTimeKey, value);
        }
        public TimeSpan StartNotifyTime
        {
            get => GetFromDictionary(StartNotifyTimeKey, new TimeSpan());
            set => SaveToDictionary(StartNotifyTimeKey, value);
        }
        public TimeSpan IntervalTimeSpan
        {
            get => GetFromDictionary(IntervalTimeSpanKey, new TimeSpan());
            set => SaveToDictionary(IntervalTimeSpanKey, value);
        }
        public bool NotifyState
        {
            get => GetFromDictionary(NotifyStateKey, true);
            set => SaveToDictionary(NotifyStateKey, value);
        }
        public bool VibrateState
        {
            get => GetFromDictionary(VibrateStateKey, true);
            set => SaveToDictionary(VibrateStateKey, value);
        }

        private T GetFromDictionary<T>(string key, T defaultValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return (T)Application.Current.Properties[key];
            }
            Application.Current.Properties[key] = defaultValue;
            return (T)Application.Current.Properties[key];
        }

        private void SaveToDictionary<T>(string key, T newValue)
        {
            Application.Current.Properties[key] = newValue;
        }

        public static async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
