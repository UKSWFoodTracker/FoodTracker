using System;
using Xamarin.Forms;

namespace FoodTracker.ViewModel.TimerService
{
    public partial class Timer
    {
        public TimerStates States
        {
            get
            {
                var app = Application.Current as App;
                return app.myProperties.TimerStates;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.TimerStates = value;
            }
        }

        private TimeSpan PauseTime
        {
            get
            {
                var app = Application.Current as App;
                return app.myProperties.PauseNotifyTime;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.PauseNotifyTime = value;
            }
        }

        /// <summary>
        /// Time when we start count down timer. 
        /// </summary>
        private TimeSpan StartTime
        {
            get
            {
                var app = Application.Current as App;
                return app.myProperties.StartNotifyTime;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.StartNotifyTime = value;
            }
        }

        public enum TimerStates
        {
            Running,
            Stoped, // ...or turned off
            Paused
        }
    }
}
