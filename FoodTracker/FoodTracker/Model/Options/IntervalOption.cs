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
            this.value = value;
        }

        private TimeSpan value;
        public override string Value
        {
            get => value.ToString();
            set => this.value = TimeSpan.Parse(value);  //string format: hh:mm
        }
    }
}
