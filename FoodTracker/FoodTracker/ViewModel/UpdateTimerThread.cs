using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace FoodTracker.ViewModel
{
    /// <summary>
    /// This class should be use as a updater for TimerValue property
    /// </summary>
    public class UpdateTimerThread
    {
        private readonly UpdateProperty _onPropertyChanged;
        public delegate void UpdateProperty(string propertyName);
        public UpdateTimerThread(UpdateProperty updaterProperty)
        {
            _onPropertyChanged = updaterProperty;

            var timerThread = new Thread(UpdateTimerProperty);

            timerThread.Start();
        }
        private void UpdateTimerProperty()
        {
            while (true)
            {
                _onPropertyChanged("TimerValue");
                Thread.Sleep(50);
            }
        }
    }
}
