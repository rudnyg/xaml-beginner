using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class OrderDataManager : DataManager
    {
        private List<MenuItem> _menuItems;
        private List<MenuItem> _currentlySelectedMenuItems;

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                this.OnPropertyChanged(nameof(MenuItems));
            }
        }

        public List<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set {          
                    _currentlySelectedMenuItems = value;
                    this.OnPropertyChanged(nameof(CurrentlySelectedMenuItems));
            }
        }


        protected override void OnDataLoaded()
        {
            _menuItems = Repository.StandardMenuItems;

            CurrentlySelectedMenuItems = new List<MenuItem>
            {
                //simulate selecting multiple items 
                _menuItems[3],
                _menuItems[5]
            };
            
        }
    }
}
