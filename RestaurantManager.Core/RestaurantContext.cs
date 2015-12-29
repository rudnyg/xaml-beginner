using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManager.Core.Models;

namespace RestaurantManager.Core
{
    public sealed class RestaurantContext
    {
        public List<Table> Tables { get; private set; }
        public List<MenuItem> StandardMenuItems { get; private set; }
        public ObservableCollection<Order> Orders { get; private set; }

        public async Task InitializeContextAsync()
        {
            //simulates a network delay
            await Task.Delay(TimeSpan.FromSeconds(0d));

            Tables = new List<Table>
            {
                new Table() {Description = "Back-Corner Two Top"},
                new Table() {Description = "Front Booth"}
            };

            StandardMenuItems = new List<MenuItem>
            {
                new MenuItem { Title = "French Bread & Fondue Dip", Price = 5.75m },
                new MenuItem { Title = "Curried Chicken and Rice", Price = 9.00m },
                new MenuItem { Title = "Feta-Stuffed Chicken", Price = 8.25m },
                new MenuItem { Title = "Grilled Pork Loin", Price = 11.50m },
                new MenuItem { Title = "Carnitas Tacos", Price = 7.50m },
                new MenuItem { Title = "Fillet Mignon & Asparagus", Price = 15.75m },
                new MenuItem { Title = "T-Bone Steak", Price = 12.25m },
                new MenuItem { Title = "Pineapple and Pear Salad", Price = 6.25m },
                new MenuItem { Title = "Sautéed Broccoli", Price = 3.75m },
                new MenuItem { Title = "Mashed Peas", Price = 3.25m }
            };

            Orders = new ObservableCollection<Order>
            {
                new Order { Complete = false, Expedite = true, SpecialRequests = "Allergic to Shellfish", Table = Tables.Last(), Items = new List<MenuItem> { StandardMenuItems.First() } },
                new Order { Complete = false, Expedite = false, SpecialRequests = string.Empty, Table = Tables.Last(), Items = new List<MenuItem> { StandardMenuItems.Last(), StandardMenuItems.First() } },
            };
        }
    }
}
