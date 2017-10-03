using System;
using System.Runtime.Remoting.Messaging;
using FoodTracker.PlatformServices.Notifications.Options;

namespace FoodTracker.ViewModel.TimerService
{
    public partial class Timer
    {
        public Timer(IntervalOption intervalOption)
        {
            _intervalOption = intervalOption;
            _relative = DateTime.Parse("09.12.2017");
            _zero = new TimeSpan(0, 0, 0, 0);
        }

        /// <summary>
        /// Reference to <seealso cref="IntervalOption.Value"/>
        /// </summary>
        private readonly IntervalOption _intervalOption;
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

        private TimeSpan Now => DateTime.Now - _relative;

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
            _endTime = StartTime + _intervalOption.Value;
            if (States == TimerStates.Paused)
            {
                _endTime += Now - PauseTime;
            }
            return _endTime - Now;
        }

        public void Start()
        {
            StartTime = Now;
        }

        /// <summary>
        /// Method used only when timer is stoped. It makes timer run again
        /// </summary>
        public void Resume()
        {
            if (States == TimerStates.Running)
                return;
            States = TimerStates.Running;
        }

        public void Pause()
        {
            if (States == TimerStates.Paused ||
                States == TimerStates.Stoped)
                return;
            States = TimerStates.Paused;

            PauseTime = Now;
        }
    }
}
