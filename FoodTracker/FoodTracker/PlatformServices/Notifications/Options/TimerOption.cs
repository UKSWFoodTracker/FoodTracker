using System;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class TimerOption : Option<TimeSpan>
    {
        public TimerOption(IntervalOption intervalOption) : base("Interval")
        {
            _intervalOption = intervalOption;
            // Get value from myProperties
            _startNotify = StartTimer;
            _pauseTimer = PauseTimer;
            _relative = DateTime.Parse("09.12.2017");
            _zero = new TimeSpan(0, 0, 0, 0);
            _isPaused = ComputeTimeLeft() <= _zero;
        }

        /// <summary>
        /// Reference to <seealso cref="IntervalOption.Value"/>
        /// </summary>
        private readonly IntervalOption _intervalOption;
        /// <summary>
        /// This field is needed to avoid performance crash in HowMuchTimeLeft property
        /// </summary>
        private readonly TimeSpan _zero;
        /// <summary>
        /// Time which indicates the beginning of an interval. 
        /// It means time when we start count down timer. 
        /// </summary>
        private TimeSpan _startNotify;
        /// <summary>
        /// According to that time we substract and add times.
        /// If sb wants get TimeSpan from DateTime structure, it's necessary. 
        /// </summary>
        private readonly DateTime _relative;
        private TimeSpan _pauseTimer;
        private bool _isPaused;
        private TimeSpan _timerEnd;

        /// <summary>
        /// Time left to the end of next interval. It should be binded with a page's controls
        /// </summary>
        public string HowMuchTimeLeft()
        {
            TimeSpan timeLeft = ComputeTimeLeft();
            if (timeLeft <= _zero)
            {
                Start();
                timeLeft = ComputeTimeLeft();
            }
            return $"{timeLeft:hh\\:mm\\:ss}";
        }

        private TimeSpan ComputeTimeLeft()
        {
            //Forecasting when timer goes off
            _timerEnd = _startNotify + _intervalOption.Value;
            TimeSpan relativeNow = DateTime.Now - _relative;
            return _timerEnd - relativeNow;
        }

        public void Start()
        {
            StartTimer = DateTime.Now - _relative;
        }

        /// <summary>
        /// Method used only when timer is stoped. It makes timer run again
        /// </summary>
        public void Resume()
        {
            if (!_isPaused)
                return;
            _isPaused = false;

            
        }

        public void Pause()
        {
            if (_isPaused)
                return;
            _isPaused = true;

            PauseTimer = DateTime.Now - _relative;
        }

        public TimeSpan PauseTimer
        {
            get
            {
                var app = Application.Current as App;
                _pauseTimer = app.myProperties.PauseNotifyTime;
                return _pauseTimer;
            }
            set
            {
                var app = Application.Current as App;
                app.myProperties.PauseNotifyTime = value;
                _pauseTimer = value;
            }
        }

        /// <summary>
        /// Property for _startNotifyTime and it saves value to MyProperties class as well. 
        /// <see cref="_startNotify"/> 
        /// </summary>
        private TimeSpan StartTimer
        {
            get
            {
                _startNotify = GetFromMyProperties();
                return _startNotify;
            }
            set
            {
                _startNotify = value;
                SaveToMyProperties(_startNotify);
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
    }
}
