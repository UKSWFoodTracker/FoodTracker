using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model.Meals
{
    public class MealModel
    {
        public MealModel(string name, int weight)
        {
            this.name = name;
            this.weight = weight;
        }
        private string name;
        private int weight;
        public string Name { get { return name; } set { name = value; } }
        public int Weight { get { return weight; } set { weight = value; } }
    }
}
