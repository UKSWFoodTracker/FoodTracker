using FoodTracker.Model;
using FoodTracker.PlatformServices.Notifications;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FoodTracker.ViewModel
{
    public class MainFeatures
    {
        private NotifyManager _notifyManager;
        public NotifyManager NotifyManager => _notifyManager;
        public MainFeatures()
        {
            _notifyManager = new NotifyManager();
        }
    }
}
