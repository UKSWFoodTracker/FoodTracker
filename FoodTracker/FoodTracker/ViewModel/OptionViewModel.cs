using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FoodTracker.ViewModel
{
    public class OptionViewModel : INotifyPropertyChanged
    {
        public OptionViewModel(Model.Option option)
        {
            this.option = option;
        }
        private Model.Option option;
        public string Name { get => option.Name; }
        public string Value
        {
            get => option.Value;
            set
            {
                option.Value = value;
                OnPropertyChanged("Value");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
