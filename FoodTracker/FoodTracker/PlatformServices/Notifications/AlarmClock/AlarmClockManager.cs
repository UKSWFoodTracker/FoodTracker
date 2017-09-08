using Android.App;
using Android.Content;
using Android.OS;
using FoodTracker.Droid;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.PlatformServices.Notifications
{
    public partial class NotifyManager
    {
        /// <summary>
        /// Class serves to show notifications
        /// </summary>
        private static class AlarmClockManager
        {
            public static MainActivity Main;    //We need reference to MainActivity located in MainActivity.cs file

            public static void StartNotification(bool isRepeating, int interval)
            {
                if (Main == null)
                {
                    Console.WriteLine("Can't show notifications because of null in MainActivity.");
                    return;
                }
                Context context = Main as Context;
                AlarmManager manager = (AlarmManager)Main.GetSystemService(Context.AlarmService);
                Intent myIntent = new Intent(context, typeof(AlarmNotificationReceiver));
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
            public static void StopNotification()
            {
                if (Main == null)
                {
                    Console.WriteLine("Can't stop notifications because of null in MainActivity.");
                    return;
                }
                Context context = Main as Context;
                Intent myIntent = new Intent(context, typeof(AlarmNotificationReceiver));
                PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, myIntent, 0);
                AlarmManager manager = (AlarmManager)Main.GetSystemService(Context.AlarmService);

                manager.Cancel(pendingIntent);
            }
        }
    }
}
