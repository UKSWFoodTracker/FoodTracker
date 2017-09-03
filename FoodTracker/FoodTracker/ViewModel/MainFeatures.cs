using FoodTracker.Model;
using FoodTracker.PlatformServices.Notifications;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace FoodTracker.ViewModel
{
    public class MainFeatures
    {
        public NotifyManager notifyManager;
        public MainFeatures(ref Settings settings)
        {
            notifyManager = new NotifyManager(ref settings);
        }

        public async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
