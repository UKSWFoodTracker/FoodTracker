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
        public delegate void EventHandler(bool isRepeating, int interval);
        public static event EventHandler NotificationEvent;

        public static void OnNotificationEvent(bool isRepeating, int interval)
        {
            NotificationEvent?.Invoke(isRepeating, interval);
        }

        public static void ShowNotification(MainActivity main, bool isRepeating, int interval)
        {
            Context context = main as Context;
            AlarmManager manager = (AlarmManager)main.GetSystemService(Context.AlarmService);
            Intent myIntent =  new Intent(context, typeof(AlarmNotificationReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, myIntent, 0);

            long now = SystemClock.ElapsedRealtime();
            if (!isRepeating)
            {
                manager.Set(AlarmType.ElapsedRealtimeWakeup, now + interval, pendingIntent);
            }
            else
            {
                manager.SetRepeating(AlarmType.ElapsedRealtimeWakeup, now + interval, interval, pendingIntent);
            }
        }
    }
}
