using System.Timers;

namespace FoodTracker.ViewModel
{
    /// <summary>
    /// This class should be use as a updater for TimerValue property
    /// </summary>
    public class UpdateTimerValue
    {
        private readonly UpdateProperty _onPropertyChanged;
        public delegate void UpdateProperty(string propertyName);
        public UpdateTimerValue(UpdateProperty updaterProperty)
        {
            _onPropertyChanged = updaterProperty;

            var timer = new Timer(500);
            timer.Elapsed += (sender, args) => UpdateTimerProperty();
            timer.Start();
        }
        private void UpdateTimerProperty()
        {
            _onPropertyChanged("TimerValue");
        }
    }
}
