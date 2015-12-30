using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Popups;
using RestaurantManager.Core.Models;

namespace RestaurantManager.Core.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        private ObservableCollection<MenuItem> _menuItems;

        private ObservableCollection<MenuItem> _currentlySelectedMenuItems;

        public DelegateCommand<MenuItem> AddMenuItemCommand { get; private set; }

        public DelegateCommand<string> SubmitOrderCommand { get; private set; }
         
        public ObservableCollection<MenuItem> MenuItems
        {
            get { return _menuItems; }
            set
            {
                _menuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }

        private string _orderSpecialRequest;

        public string OrderSpecialRequest
        {
            get { return _orderSpecialRequest; }
            set { _orderSpecialRequest = value;  OnPropertyChanged(nameof(OrderSpecialRequest));}
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
            MenuItems = new ObservableCollection<MenuItem>(Repository.StandardMenuItems);

            CurrentlySelectedMenuItems = new ObservableCollection<MenuItem>();
            AddMenuItemCommand = new DelegateCommand<MenuItem>(OnAddMenItem);
            SubmitOrderCommand = new DelegateCommand<string>(OnSubmitMenuItem);
        }

        private void OnSubmitMenuItem(string param)
        {
            var order = new Order() {Items = new List<MenuItem>()};
            foreach (var menuItem in _currentlySelectedMenuItems)
            {
                order.Items.Add(menuItem);
            }
            //temp set table default 
            order.Table = new Table( ) {Description = "Near the bar"};
            //add special request  
            order.SpecialRequests = OrderSpecialRequest; 
            //save to repo 
            Repository.Orders.Add(order);
            //clear the list after added 
            _currentlySelectedMenuItems.Clear();
            OrderSpecialRequest = string.Empty;
            new MessageDialog("Order Submitted").ShowAsync();
        }

        private void OnAddMenItem(MenuItem item)
        {
            _currentlySelectedMenuItems.Add(item);
        }
    }
}
