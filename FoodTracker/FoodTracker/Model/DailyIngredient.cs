using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodTracker.Model
{
    class DailyIngredient : INotifyPropertyChanged
    {
        public DailyIngredient()
        {

        }
        public DailyIngredient(Ingredient ingredient, DateTime date)
        {

        }
        [PrimaryKey, AutoIncrement]
        public int DailyIngredientId { get; set; }
        public int IngredientId { get; set; }
        private DateTime date;
        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (date == value)
                {
                    return;
                }

                date = value;
                OnPropertyChange();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
