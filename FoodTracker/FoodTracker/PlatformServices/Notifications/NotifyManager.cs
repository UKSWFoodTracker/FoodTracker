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
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification()
        {
            AlarmClockManager.ShowNotification(true, (int)settings.IntervalValue.TotalMilliseconds);
        }
    }
}
