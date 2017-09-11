using FoodTracker.PlatformServices.Notifications;

namespace FoodTracker.ViewModel
{
    public class MainFeatures
    {
        private NotifyManager _notifyManager;
        public MainFeatures()
        {
            _notifyManager = new NotifyManager();
        }
        public void StartNotification(int intervalTotalMiliseconds)
        {
            _notifyManager.StartNotification(intervalTotalMiliseconds);
        }
        public void StopNotification()
        {
            _notifyManager.StopNotification();
        }
    }
}
