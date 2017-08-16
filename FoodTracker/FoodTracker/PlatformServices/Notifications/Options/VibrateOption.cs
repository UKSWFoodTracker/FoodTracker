using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.PlatformServices.Notifications.Options
{
    class VibrateOption : Option
    {
        public VibrateOption(string name, bool value) : base(name)
        {
            onState = value;
        }
        private bool onState;
        public bool OnState
        {
            get => onState;
            set => onState = value;
        }
    }
}
