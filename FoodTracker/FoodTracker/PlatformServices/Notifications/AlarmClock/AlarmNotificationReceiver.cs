using Android;
using Android.App;
using Android.Content;
using Android.Support.V7.App;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.PlatformServices.Notifications
{
    public partial class NotifyManager
    {
        [BroadcastReceiver(Enabled = true)]
        private class AlarmNotificationReceiver : BroadcastReceiver
        {
            private string _title;
            public string Title { set { _title = value; } }
            private string _text;
            public string Text { set { _text = value; } }
            private string _info;
            public string Info { set { _info = value; } }
            public AlarmNotificationReceiver()
            {
                _title = "Alarm Actived!";
                _text = "THIS IS MY ALARM";
                _info = "Info";
            }
            public override void OnReceive(Context context, Intent intent)
            {
                NotificationCompat.Builder builder = new NotificationCompat.Builder(context);

                builder.SetAutoCancel(true)
                    .SetDefaults((int)NotificationDefaults.All)
                    .SetSmallIcon(Resource.Drawable.SymDefAppIcon)
                    .SetContentTitle(_title)
                    .SetContentText(_text)
                    .SetContentInfo(_info);


                NotificationManager manager = (NotificationManager)context.GetSystemService(Context.NotificationService);
                manager.Notify(1, builder.Build());
            }
        }
    }
}
