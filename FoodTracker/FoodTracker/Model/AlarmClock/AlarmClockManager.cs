using Android.App;
using Android.Content;
using Android.OS;
using FoodTracker.Droid;
using FoodTracker.Model.AlarmClock.BroadCast;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model.AlarmClock
{
    public static class AlarmClockManager
    {
        public delegate void EventHandler(bool isRepeating, TimeSpan interval);
        public static event EventHandler NotificationEvent;

        public static void OnNotificationEvent(bool isRepeating, TimeSpan interval)
        {
            NotificationEvent?.Invoke(isRepeating, interval);
        }

        public static void ShowNotification(MainActivity main, bool isRepeating, TimeSpan interval)
        {
            AlarmManager manager = (AlarmManager)main.GetSystemService(Context.AlarmService);
            Intent myIntent;
            PendingIntent pendingIntent;

            myIntent = new Intent(main, typeof(AlarmNotificationReceiver));
            pendingIntent = PendingIntent.GetBroadcast(main, 0, myIntent, PendingIntentFlags.CancelCurrent);

            if (!isRepeating)
            {
                manager.Set(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, pendingIntent);
            }
            else
            {
                manager.SetRepeating(AlarmType.RtcWakeup, SystemClock.ElapsedRealtime() + 3000, 60 * 1000, pendingIntent);
            }
        }
    }
}
