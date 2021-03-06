﻿using System.Collections.ObjectModel;
using Windows.UI.Popups;
using RestaurantManager.Core.Models;

namespace RestaurantManager.Core.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        
        public DelegateCommand<Order> DeleteOrderCommand { get;  private set; }
        public DelegateCommand<Order> DeleteAllOrdersCommand { get; private set; }

        protected override void OnDataLoaded()
        {
            DeleteOrderCommand = new DelegateCommand<Order>(OnDeleteOrder);
            DeleteAllOrdersCommand = new DelegateCommand<Order>(OnDeleteAllOrders);
            OrderItems = Repository.Orders;
        }

        private ObservableCollection<Order> _orderItems; 
        public ObservableCollection<Order> OrderItems
        {
            get { return _orderItems; }
            set
            {
                _orderItems = value;
                OnPropertyChanged(nameof(OrderItems));
            }
        }


        private void OnDeleteOrder(Order orderToDelete)
        {
            string order = orderToDelete.ToString();
            OrderItems.Remove(orderToDelete);
            new MessageDialog($"Order is deleted: {order}").ShowAsync();

        }

        private void OnDeleteAllOrders(Order obj)
        {
            OrderItems.Clear();
            new MessageDialog("All orders cleared.").ShowAsync();
        }
    }
}
