using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FoodTracker.Model.Options
{
    class IntervalOption : Option
    {
        private TimeSpan value;
        public override string Value
        {
            get => value.ToString();
            set => this.value = TimeSpan.Parse(value);  //string format: hh:mm
        }

        public IntervalOption(string name, string pageToOpen) : base(name, pageToOpen)
        {
            value = new TimeSpan(0, 1, 0);
        }
    }
}
