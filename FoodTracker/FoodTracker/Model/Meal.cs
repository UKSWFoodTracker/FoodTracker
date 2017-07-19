using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model
{
    public class Meal
    {
        public List<Food> foodList;
        public Meal()
        {
            foodList = new List<Food>();
        }

        public void Add(Food item)
        {
            foodList.Add(item);
        }

        public void Delete(Food item)
        {
            foodList.Remove(item);
        }
    }
}
