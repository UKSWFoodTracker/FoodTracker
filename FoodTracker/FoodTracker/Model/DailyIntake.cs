using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodTracker.Model
{
    // Dzienne spożycie
    class DailyIntake : INotifyPropertyChanged
    {
        public DailyIntake()
        {
            date = DateTime.Now;
            totalCalories = 0;
            int enumCount = Enum<IngredientType>.Count;
            caloriesType = new int[enumCount];
            for (int i = 0; i < enumCount; i++)
            {
                caloriesType[i] = 0;
            }
        }
        public DailyIntake(DateTime date, int totalCalories, int[] caloriesPerType)
        {
            this.date = date;
            this.totalCalories = totalCalories;
            caloriesType = new int[Enum<IngredientType>.Count];
            if (caloriesPerType.Length == Enum<IngredientType>.Count || 
                caloriesPerType.Length > Enum<IngredientType>.Count)
            {
                for (int i = 0; i < Enum<IngredientType>.Count; i++)
                {
                    caloriesType[i] = caloriesPerType[i];
                }
            }
            else if (caloriesPerType.Length < Enum<IngredientType>.Count)
            {
                for (int i = 0; i < Enum<IngredientType>.Count; i++)
                {
                    if (i < caloriesPerType.Length)
                    {
                        caloriesType[i] = caloriesPerType[i];
                    }
                    else
                    {
                        caloriesType[i] = 0;
                    }
                }
            }
        }
        [PrimaryKey, AutoIncrement]
        public int DailyIntakeId { get; set; }
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
        private int totalCalories;
        public int TotalCalories
        {
            get
            {
                return totalCalories;
            }
            set
            {
                if (totalCalories == value)
                {
                    return;
                }

                totalCalories = value;
                OnPropertyChange();
            }
        }
        // stores daily intake for each food type: index 0 has calories for Meat, index 1 for Bread, etc.
        private int[] caloriesType;  
        public int[] CaloriesType
        {
            get
            {
                return caloriesType;
            }
            set
            {
                if (caloriesType == value)
                {
                    return;
                }

                caloriesType = value;
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
