﻿using System;
using FoodTracker.PlatformServices.Notifications.Options;
using System.ComponentModel;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace FoodTracker.ViewModel
{
    //Main class to manage options
    public class Settings :INotifyPropertyChanged
    {
        private UpdateTimerValue _updateTimerValue;
        private readonly TimerOption _timer;
        private readonly IntervalOption _interval;
        private readonly NotifyOption _notify;
        public Settings()
        {
            //Loading pop-up interval from saved properties
            _interval = new IntervalOption("Pop-ups interval");
            _notify = new NotifyOption("Notification");
            _timer = new TimerOption("Timer", _interval.Value);
            // TODO: ADDING NEW OPTION: creating object

            _updateTimerValue = new UpdateTimerValue(OnPropertyChanged);
        }

        // Interval option properties
        public string IntervalName => _interval.Name;

        public string IntervalValueString
        {
            get => String.Format("{0:hh\\:mm\\:ss}", _interval.Value);
            set
            {
                TimeSpan timeValue = TimeSpan.Parse(value);
                _interval.Value = timeValue;
                var app = Application.Current as App;
                if (app != null) app.myProperties.IntervalTimeSpan = timeValue;
                OnPropertyChanged();
            }
        }
        public TimeSpan IntervalValueTimeSpan
        {
            get => _interval.Value;
            set
            {
                TimeSpan timeValue = value;
                _interval.Value = timeValue;
                var app = Application.Current as App;
                if (app != null) app.myProperties.IntervalTimeSpan = timeValue;
                OnPropertyChanged();
            }
        }
        public string NotifyName
        {
            get => _notify.Name;
        }
        public bool NotifyValue
        {
            get => _notify.Value;
            set
            {
                _notify.Value = value;
                // Saving in app properties
                var app = Application.Current as App;
                if (app != null) app.myProperties.NotifyState = value;
                // Cancel notification request
                if (value)
                {
                    OnStopRequest();
                }
                else
                {
                    OnStartRequest();
                    _timer.SetTimer();
                }

                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Update string in MainPage's "On/Off" button
        /// </summary>
        public string NotifyButton
        {
            get
            {
                OnPropertyChanged();
                return !_notify.Value ? "On" : "Off";
            }
        }

        public string TimerValue {
            get
            {
                if (!NotifyValue)
                {
                    return "Interval off";
                }
                return _timer.HowMuchTimeLeft(IntervalValueTimeSpan);
            }
        }
        // TODO: ADDING NEW OPTION: properties

        /// <summary>
        /// Update specified value in form
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        /// <summary>
        /// Request to stop notifications
        /// </summary>
        public static event StartRequestHandler StartNotifyRequestEvent;
        public delegate void StartRequestHandler(int intervalTotalMiliseconds);
        private void OnStopRequest()
        {
            StartRequestHandler request = StartNotifyRequestEvent;
            request?.Invoke((int)IntervalValueTimeSpan.TotalMilliseconds);
        }
        /// <summary>
        /// Request to start notifications
        /// </summary>
        public static event StopRequestHandler StopNotifyRequestEvent;
        public delegate void StopRequestHandler();
        private void OnStartRequest()
        {
            StopRequestHandler request = StopNotifyRequestEvent;
            request?.Invoke();
        }
    }
}
