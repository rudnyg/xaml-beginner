using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using RestaurantManager.Core.Models;

namespace RestaurantManager.Core.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private List<MenuItem> _menuItems;

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

      

        public List<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        public ObservableCollection<MenuItem> CurrentlySelectedMenuItems
        {
            get { return _currentlySelectedMenuItems; }
            set {          
                    _currentlySelectedMenuItems = value;
                    OnPropertyChanged(nameof(CurrentlySelectedMenuItems));
            }
        }

        protected override void OnDataLoaded()
        {
            _menuItems = Repository.StandardMenuItems;

            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>
            {
                //simulate selecting multiple items 
                _menuItems[3],
                _menuItems[5]
            };


                 
        }

    }
}
