using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model
{
    public enum IngredientType
    {
        [Description("Meat")]
        Meat,
        [Description("Bread")]
        Bread,
        [Description("Seafood")]
        Seafood,
        [Description("Eggs")]
        Eggs,
        [Description("Dairy products")]
        DairyProducts,
        [Description("Fruits")]
        Fruits,
        [Description("Vegetables")]
        Vegetables
    };

    // That attribute helps convert enum to string
    [AttributeUsage(AttributeTargets.Field, 
        AllowMultiple = true, 
        Inherited = false)]
    public class DescriptionAttribute :Attribute
    {
        private string description; // stores message which will be printed
        public string Description { get { return description; } }

        public DescriptionAttribute(string _description)
        {
            description = _description;
        }
    }
}
