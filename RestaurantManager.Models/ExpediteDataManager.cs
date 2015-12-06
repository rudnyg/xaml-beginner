using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManager.Models
{
    public class ExpediteDataManager : DataManager
    {
        protected override void OnDataLoaded()
        {
           
        }

        public List<Order> OrderItems
        {
            get { return Repository.Orders; }
            set
            {
                  OrderItems = value;
                    this.OnPropertyChanged(nameof(OrderItems));
            }
        }
    }
}
