using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using FoodTracker.Droid;
using FoodTracker.PlatformServices.Notifications.Options;

namespace FoodTracker.PlatformServices.Notifications
{
    /// <summary>
    /// Class manages notifications' all settings and features
    /// </summary>
    public partial class NotifyManager
    {
        private Settings settings;
        public NotifyManager(ref Settings settings)
        {
            this.settings = settings;
            settings.StopRequestEvent += StopNotification;
        }

        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification()
        {
            TimeSpan interval = TimeSpan.Parse(settings.IntervalValue);
            AlarmClockManager.ShowNotification(true, (int)interval.TotalMilliseconds);
        }
        public void StopNotification()
        {
            if (!settings.NotifyValue)
            {
                AlarmClockManager.StopNotification();
            }
        }
    }
}
