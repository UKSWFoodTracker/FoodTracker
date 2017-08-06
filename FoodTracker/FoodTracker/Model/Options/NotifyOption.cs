using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model.Options
{
    class NotifyOption : Option
    {
        public NotifyOption(string name, bool value) : base(name)
        {
            onState = value;
        }
        private bool onState;   // Określa czy notyfikacje mają być włączone lub nie
        public bool OnState
        {
            get => onState;
            set => onState = value;
        }
    }
}
