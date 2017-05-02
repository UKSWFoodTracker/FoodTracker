using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model
{
    //Main class to manage options
    class Settings
    {
        public Settings()
        {
            options = new List<Option>()
            {
                new Options.IntervalOption("Interval", new TimeSpan(0, 1, 0)),
                // TODO: ADDING NEW OPTIONS
            };
        }
        private List<Option> options;
        public List<Option> GetOptions { get { return options; } }
    }
}
