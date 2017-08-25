using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using FoodTracker.Droid;
using FoodTracker.PlatformServices.Notifications.Options;
using Xamarin.Forms;

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
        private TimeSpan startNotifyTime;
        /// <summary>
        /// Time left to the end of next interval
        /// </summary>
        public string IntervalEndTimeSpan
        {
            get
            {
                TimeSpan time = startNotifyTime - (DateTime.Now - DateTime.Parse("01.01.2000"));
                return String.Format("{0:hh\\:mm\\:ss}", time);
            }
        }
        private TimeSpan getStartNotifyTime()
        {
            var app = Application.Current as App;
            return app.myProperties.StartNotifyTime;
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification()
        {
            startNotifyTime = settings.IntervalValueTimeSpan + (DateTime.Now - DateTime.Parse("01.01.2000"));
            var app = Application.Current as App;
            app.myProperties.StartNotifyTime = startNotifyTime;

            TimeSpan interval = settings.IntervalValueTimeSpan;
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
