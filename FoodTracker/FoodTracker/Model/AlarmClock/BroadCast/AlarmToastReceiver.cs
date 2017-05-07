using Android.Content;
using Android.Widget;

namespace FoodTracker.Model.AlarmClock.BroadCast
{

    namespace XamarinAlarmDemo.BroadCast
    {
        [BroadcastReceiver(Enabled = true)]
        public class AlarmToastReceiver : BroadcastReceiver
        {
            public override void OnReceive(Context context, Intent intent)
            {
                Toast.MakeText(context, "THIS IS MY ALARM", ToastLength.Long).Show();
            }
        }
    }
}
