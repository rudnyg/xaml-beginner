﻿namespace RestaurantManager.Core.Models
{
    public class Table
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Description;
        }
    }
}
