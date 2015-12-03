using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        public List<MenuItem> MenuItems { get; set; }
        public List<MenuItem> CurrentlySelectedMenuItems { get; set; }


        protected override void OnDataLoaded()
        {
            MenuItems = Repository.StandardMenuItems;

            CurrentlySelectedMenuItems = new List<MenuItem>
            {
                //simulate selecting multiple items 
                MenuItems[3],
                MenuItems[5]
            };
        }
    }
}
