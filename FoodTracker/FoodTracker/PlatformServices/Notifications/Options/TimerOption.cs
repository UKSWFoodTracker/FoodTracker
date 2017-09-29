using System;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    public class TimerOption : Option<TimeSpan>
    {
        public TimerOption(IntervalOption intervalOption) : base("Interval")
        {
            _intervalOption = intervalOption;
            _startTime = StartTime;
            _relative = DateTime.Parse("09.12.2017");
            _zero = new TimeSpan(0, 0, 0, 0);
        }

        /// <summary>
        /// Reference to <seealso cref="IntervalOption.Value"/>
        /// </summary>
        private readonly IntervalOption _intervalOption;
        /// <summary>
        /// Time when we start count down timer. 
        /// </summary>
        private TimeSpan _startTime;
        /// <summary>
        /// According to that time we substract and add times.
        /// If sb wants get TimeSpan from DateTime structure, it's necessary. 
        /// </summary>
        private readonly DateTime _relative;
        private readonly TimeSpan _zero;
        /// <summary>
        /// Forecasting when timer goes off
        /// </summary>
        private TimeSpan _endTime;

        /// <summary>
        /// Time left to the end of next interval. It should be binded with a page's controls
        /// </summary>
        public (string StringValue, TimeSpan TimeValue) HowMuchTimeLeft()
        {
            TimeSpan timeLeft = ComputeTimeLeft();
            if (timeLeft <= _zero)
            {
                Start();
                timeLeft = ComputeTimeLeft();
            }
            return ($"{timeLeft:hh\\:mm\\:ss}", timeLeft);
        }

        private TimeSpan ComputeTimeLeft()
        {
            _endTime = _startTime + _intervalOption.Value;
            TimeSpan relativeNow = DateTime.Now - _relative;
            if (State == TimerState.Paused)
            {
                _endTime += relativeNow - PauseTime;
            }
            return _endTime - relativeNow;
        }

        public void Start()
        {
            StartTime = DateTime.Now - _relative;
        }

        /// <summary>
        /// Method used only when timer is stoped. It makes timer run again
        /// </summary>
        public void Resume()
        {
            if (State == TimerState.Running)
                return;
            State = TimerState.Running;
        }

        public void Pause()
        {
            if (State == TimerState.Paused ||
                State == TimerState.Stoped)
                return;
            State = TimerState.Paused;

            PauseTime = DateTime.Now - _relative;
        }

        public TimerState State
        {
            get
            {
                var app = Application.Current as App;
                return app.myProperties.TimerState;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.TimerState = value;
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
        /// Property for _startNotifyTime and it saves value to MyProperties class as well. 
        /// <see cref="_startTime"/> 
        /// </summary>
        private TimeSpan StartTime
        {
            get
            {
                _startTime = GetFromMyProperties();
                return _startTime;
            }
            set
            {
                _startTime = value;
                SaveToMyProperties(_startTime);
            }
        }

        protected override TimeSpan GetFromMyProperties()
        {
            var app = Application.Current as App;
            return app.myProperties.StartNotifyTime;
        }
        
        protected override void SaveToMyProperties(TimeSpan value)
        {
            var app = Application.Current as App;
            app.myProperties.StartNotifyTime = value;
        }

        public enum TimerState
        {
            Running,
            Stoped, // ...or turned off
            Paused
        }
    }
}
