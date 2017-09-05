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
        public NotifyManager()
        {
            Settings.StopRequestEvent += StopNotification;
            Settings.StartRequestEvent += StartNotification;
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification(int intervalTotalMiliseconds)
        {
            AlarmClockManager.ShowNotification(true, intervalTotalMiliseconds);
        }
        public void StopNotification()
        {
            AlarmClockManager.StopNotification();
        }
    }
}
