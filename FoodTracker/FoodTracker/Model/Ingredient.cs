using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FoodTracker.Model
{
    public class Ingredient :INotifyPropertyChanged
    {
        public Ingredient()
        {
            name = "Ingredient";
            weight = 0;
            calories100 = 0;
        }
        public Ingredient(string _name, int _weight, int _calories100, IngredientType _type)
        {
            name = _name;
            weight = _weight;
            calories100 = _calories100;
            type = _type;
        }
        [PrimaryKey, AutoIncrement]
        public int IngredientId { get; set; }
        private string name;
        [MaxLength(255)]
        public string Name
        {
            get { return name; }
            set
            {
                if (name == value)
                {
                    return;
                }

                name = value;
                OnPropertyChange();
            }
        }
        private int weight;
        public int Weight
        {
            get
            {
                return weight;
            }
            set
            {
                if (weight == value)
                {
                    return;
                }

                weight = value;
                OnPropertyChange();
            }
        }
        private int calories100;
        public int Calories100
        {
            get
            {
                return calories100;
            }
            set
            {
                if (calories100 == value)
                {
                    return;
                }

                calories100 = value;
                OnPropertyChange();
            }
        }
        private IngredientType type;
        public IngredientType Type
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
        //TODO: Should PropertyChange event be in model layer?
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChange([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
