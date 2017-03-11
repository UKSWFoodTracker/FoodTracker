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
                new Options.IntervalOption("Interval", "IntervalOptionPage"),
            };
        }
        private List<Option> options;
        public List<Option> GetOptions { get { return options; } }
    }
}
