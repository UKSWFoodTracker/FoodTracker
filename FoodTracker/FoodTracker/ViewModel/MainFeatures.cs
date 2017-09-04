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
        public MainFeatures(ref Settings settings)
        {
            _notifyManager = new NotifyManager(ref settings);
        }
        public async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
