using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RestaurantManager.Models
{
    public abstract class DataManager
    {
        public RestaurantContext Repository { get; private set; }

        public DataManager()
        {
            LoadData();
        }

        private async  void LoadData()
        {
           Repository = new RestaurantContext();
            await Repository.InitializeContextAsync();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();
    }
}