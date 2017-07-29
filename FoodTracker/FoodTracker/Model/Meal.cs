using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodTracker.Model
{
    public class Meal : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public List<Food> foodList; // składniki
        private int caloriesSum;    // suma kalorii
        public int CaloriesSum
        {
            get
            {
                return caloriesSum;
            }
            set
            {
                if (caloriesSum == value)
                {
                    return;
                }

                caloriesSum = value;
                OnPropertyChange();
            }
        }
        private DateTime date;      // data spożycia posiłku
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
        public Meal(DateTime date)
        {
            foodList = new List<Food>();
            this.date = date;
        }
        public Meal(DateTime date, IEnumerable<Food> foodsCollection)
        {
            foodList = new List<Food>(foodsCollection);
            this.date = date;
        }

        public void Add(Food item)
        {
            foodList.Add(item);
        }

        public void Delete(Food item)
        {
            foodList.Remove(item);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
