using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.Model.Options
{
    class IntervalOption : Option
    {
        public IntervalOption(string name, TimeSpan value) : base(name)
        {
            this.timePeriod = value;
        }

        private TimeSpan timePeriod;
        public override string TimePeriod
        {
            get => timePeriod.ToString();
            set => this.timePeriod = TimeSpan.Parse(value);  //string format: hh:mm
        }
    }
}
