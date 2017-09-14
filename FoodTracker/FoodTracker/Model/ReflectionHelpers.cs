using System;

namespace FoodTracker.Model
{
    /// <summary>
    /// Class helps convert enum to string and any other type
    /// </summary>
    public static class ReflectionHelpers
    {
        public static string GetCustomDescription(object objEnum)
        {
            var fi = objEnum.GetType().GetField(objEnum.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : objEnum.ToString();
        }

        /// <summary>
        /// Extension method means sb can use IngredientType.Description() to get description
        /// </summary>
        public static string Description(this Enum value)
        {
            return GetCustomDescription(value);
        }
    }

    /// <summary>
    /// Extension to enum type returns amount of implemented values in enum
    /// </summary>
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
