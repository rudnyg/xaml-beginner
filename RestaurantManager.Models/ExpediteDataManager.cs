using System;
using System.Collections.Generic;
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

        public List<Order> OrderItems => base.Repository.Orders;
    }
}
