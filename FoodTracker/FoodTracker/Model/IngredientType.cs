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

    // That class helps convert enum to string and any other type
    public static class ReflectionHelpers
    {
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        // extension method means sb can use IngredientType.Description() to get description
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }

    public class Enum<T> where T : struct, IConvertible
    {
        public static int Count
        {
            get
            {
                if (!typeof(T).IsEnum)
                    throw new ArgumentException("T must be an enumerated type");

                return Enum.GetNames(typeof(T)).Length;
            }
        }
    }
}
