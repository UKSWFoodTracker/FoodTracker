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
        /// <summary>
        /// Time which indicates the beginning of an interval
        /// </summary>
        private TimeSpan startNotifyTime;
        /// <summary>
        /// According to that time we substract and add times
        /// </summary>
        private DateTime zeroTime;
        public NotifyManager(ref Settings settings)
        {
            this.settings = settings;

            startNotifyTime = getStartNotifyTime();

            zeroTime = DateTime.Parse("01.01.2000");

            settings.StopRequestEvent += StopNotification;
        }
        /// <summary>
        /// Time left to the end of next interval. It should be binded with a page's controls
        /// </summary>
        public string IntervalEndTimeSpan
        {
            get
            {
                TimeSpan time = startNotifyTime - (DateTime.Now - zeroTime);
                return String.Format("{0:hh\\:mm\\:ss}", time);
            }
        }
        private TimeSpan getStartNotifyTime()
        {
            var app = Application.Current as App;
            return app.myProperties.StartNotifyTime;
        }
        private void setStartNotifyTime(ref TimeSpan time)
        {
            var app = Application.Current as App;
            app.myProperties.StartNotifyTime = time;
            startNotifyTime = time;
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification()
        {
            startNotifyTime = settings.IntervalValueTimeSpan + (DateTime.Now - zeroTime);
            setStartNotifyTime(ref startNotifyTime);

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
