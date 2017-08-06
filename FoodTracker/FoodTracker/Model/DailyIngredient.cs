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
            ingredients = null;
            date = DateTime.Now;
            type = MealType.Breakfast;
        }
        public DailyIngredient(IEnumerable<Ingredient> ingredients, DateTime date, MealType type)
        {
            this.ingredients = ingredients as List<Ingredient>;
            this.date = date;
            this.type = type;
        }
        private List<Ingredient> ingredients;
        [PrimaryKey, AutoIncrement]
        public int DailyIngredientId { get; set; }
        public int IngredientId(int index)
        {
            return ingredients[index].Id;
        }
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
        private MealType type;
        public MealType Type
        {
            get
            {
                return type;
            }
            set
            {
                if (type == value)
                {
                    return;
                }

                type = value;
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
