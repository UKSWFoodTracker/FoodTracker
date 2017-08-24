using System;
using System.Collections.Generic;
using System.Text;
using FoodTracker.Model;
using FoodTracker.PlatformServices.Notifications;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace FoodTracker.ViewModel
{
    public class MainFeatures
    {
        public Settings settings;
        public NotifyManager notifyManager;
        public MainFeatures()
        {
            settings = new Settings();
            notifyManager = new NotifyManager(ref settings);
        }

        public async Task SaveProperties()
        {
            await Application.Current.SavePropertiesAsync();
        }
    }
}
