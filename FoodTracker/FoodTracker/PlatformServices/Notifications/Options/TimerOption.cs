using System;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class TimerOption : Option<TimeSpan>
    {
        public TimerOption(IntervalOption intervalOption) : base(name)
        {
            // Get value from myProperties
            _startNotifyTime = StartNotifyTimer;

            _relativeTime = DateTime.Parse("09.12.2017");
            _zeroTime = new TimeSpan(0, 0, 0, 0);

            _intervalOption = intervalOption;
        }

        /// <summary>
        /// Reference to <seealso cref="IntervalOption.Value"/>
        /// </summary>
        private readonly IntervalOption _intervalOption;

        /// <summary>
        /// This field is needed to avoid performance crash in HowMuchTimeLeft property
        /// </summary>
        private readonly TimeSpan _zeroTime;
        
        /// <summary>
        /// Time which indicates the beginning of an interval. 
        /// It means time when we start count down timer. 
        /// </summary>
        private TimeSpan _startNotifyTime;
        
        /// <summary>
        /// According to that time we substract and add times
        /// </summary>
        private readonly DateTime _relativeTime;

        /// <summary>
        /// Time left to the end of next interval. It should be binded with a page's controls
        /// </summary>
        public string HowMuchTimeLeft()
        {
            TimeSpan timeLeft = ComputeTimeLeft();
            if (timeLeft <= _zeroTime)
            {
                SetTimer();
                timeLeft = ComputeTimeLeft();
            }
            return String.Format("{0:hh\\:mm\\:ss}", timeLeft);
        }

        private TimeSpan ComputeTimeLeft()
        {
            TimeSpan forecastedTime = _startNotifyTime + _intervalOption.Value;
            TimeSpan relativeNow = DateTime.Now - _relativeTime;
            return forecastedTime - relativeNow;
        }

        public void SetTimer()
        {
            //Forecasting when timer goes off
            StartNotifyTimer = DateTime.Now - _relativeTime;
        }

        /// <summary>
        /// Property for _startNotifyTime and it saves value to MyProperties class as well. 
        /// <see cref="_startNotifyTime"/> 
        /// </summary>
        private TimeSpan StartNotifyTimer
        {
            get
            {
                _startNotifyTime = GetFromMyProperties();
                return _startNotifyTime;
            }
            set
            {
                _startNotifyTime = value;
                SaveToMyProperties(_startNotifyTime);
            }
        }

        /// <summary>
        /// This class don't need that method yet it has to be because of Option class
        /// <seealso cref="Option{T}"/>
        /// </summary>
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
