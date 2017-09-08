using System;
using Xamarin.Forms;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class TimerOption : Option<TimeSpan>
    {
        public TimerOption(string name, TimeSpan userInterval) : base(name)
        {
            //Get value from myProperties
            _startNotifyTime = StartNotifyTimer;

            _relativeTime = DateTime.Parse("01.01.2000");
            _zeroTime = new TimeSpan(0, 0, 0, 0);

            _userInterval = userInterval;
        }

        /// <summary>
        /// Reference to <seealso cref="IntervalOption.Value"/>
        /// </summary>
        private readonly TimeSpan _userInterval;

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
        public string HowMuchTimeLeft(TimeSpan intervalSpan)
        {
            TimeSpan time = (_startNotifyTime + intervalSpan) - (DateTime.Now - _relativeTime);
            if (time <= _zeroTime)
            {
                SetTimer();
            }
            return String.Format("{0:hh\\:mm\\:ss}", time);
        }

        /// <summary>
        /// Property for startNotifyTime and it saves value to MyProperties class as well. 
        /// <see cref="_startNotifyTime"/> 
        /// </summary>
        private TimeSpan StartNotifyTimer
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
                _startNotifyTime = value;
            }
        }

        public void SetTimer()
        {
            //Forecasting when timer goes off
            _startNotifyTime = _userInterval + (DateTime.Now - _relativeTime);
            StartNotifyTimer = _startNotifyTime;
        }

        /// <summary>
        /// This class don't need that method
        /// </summary>
        /// <returns></returns>
        protected override TimeSpan GetFromMyProperties()
        {
            throw new NotImplementedException();
        }
    }
}
