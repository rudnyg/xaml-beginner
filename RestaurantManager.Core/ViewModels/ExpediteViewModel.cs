using System.Collections.ObjectModel;
using Windows.UI.Popups;
using RestaurantManager.Core.Models;

namespace RestaurantManager.Core.ViewModels
{
    public class ExpediteViewModel : ViewModel
    {
        public DelegateCommand<Order> DeleteOrderCommand { get; set; }
        public DelegateCommand<Order> DeleteAllOrdersCommand { get; set; }

        protected override void OnDataLoaded()
        {
            DeleteOrderCommand = new DelegateCommand<Order>(OnDeleteOrder);
            DeleteAllOrdersCommand = new DelegateCommand<Order>(OnDeleteAllOrders);
        }

      

        public ObservableCollection<Order> OrderItems
        {
            get { return Repository.Orders; }
            set
            {
                  OrderItems = value;
                    this.OnPropertyChanged(nameof(OrderItems));
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
