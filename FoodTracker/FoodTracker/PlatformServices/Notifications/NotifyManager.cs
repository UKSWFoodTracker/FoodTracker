using System;
using FoodTracker.ViewModel;
using FoodTracker.Droid;

namespace FoodTracker.PlatformServices.Notifications
{
    /// <summary>
    /// Class manages notifications' feature
    /// </summary>
    public partial class NotifyManager
    {
        public NotifyManager()
        {
            Settings.StopNotifyRequestEvent += StopNotification;
            Settings.StartNotifyRequestEvent += StartNotification;
        }
        public static void SetMainActivity(MainActivity main)
        {
            AlarmClockManager.Main = main;
        }
        public void StartNotification(int intervalTotalMiliseconds)
        {
            AlarmClockManager.StartNotification(true, intervalTotalMiliseconds);
        }
        public void StopNotification()
        {
            AlarmClockManager.StopNotification();
        }
    }
}
