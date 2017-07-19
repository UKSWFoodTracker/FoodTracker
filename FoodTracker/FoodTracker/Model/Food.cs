using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodTracker.Model
{
    public class Food
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public int Weight { get; set; }
    }
}
