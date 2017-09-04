using System;
using FoodTracker.ViewModel;
using FoodTracker.Droid;

namespace FoodTracker.PlatformServices.Notifications
{
    /// <summary>
    /// Class manages notifications' all settings and features
    /// </summary>
    public partial class NotifyManager
    {
        private Settings _settings;
        public NotifyManager(ref Settings settings)
        {
            _settings = settings;

            settings.StopRequestEvent += StopNotification;
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification()
        {
            _settings.SetTimer();

            TimeSpan interval = _settings.IntervalValueTimeSpan;
            AlarmClockManager.ShowNotification(true, (int)interval.TotalMilliseconds);
        }
        public void StopNotification()
        {
            if (!_settings.NotifyValue)
            {
                AlarmClockManager.StopNotification();
            }
        }
    }
}
