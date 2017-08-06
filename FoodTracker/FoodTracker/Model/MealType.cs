using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model
{
    public enum MealType
    {
        [Description("Breakfast")]
        Breakfast,
        [Description("Dinner")]
        Dinner,
        [Description("Supper")]
        Supper,
        [Description("Afternoon Tea")]
        AfternoonTea,
    }
}
