using Android;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.PlatformServices.Notifications.AlarmClock
{
    [BroadcastReceiver(Enabled = true)]
    public class AlarmNotificationReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(context);

            builder.SetAutoCancel(true)
                .SetDefaults((int)NotificationDefaults.All)
                .SetSmallIcon(Resource.Drawable.SymDefAppIcon)
                .SetContentTitle("Alarm Actived!")
                .SetContentText("THIS IS MY ALARM")
                .SetContentInfo("Info");


            NotificationManager manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
            manager.Notify(1, builder.Build());
        }
    }
}
