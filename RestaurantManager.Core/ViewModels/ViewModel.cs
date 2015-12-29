using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models.Annotations;

namespace RestaurantManager.Core.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public RestaurantContext Repository { get; private set; }

        public ViewModel()
        {
            LoadData();
        }

        private async  void LoadData()
        {
           this.Repository = await RestaurantContextFactory.GetRestaurantContext();
            OnDataLoaded();
        }

        protected abstract void OnDataLoaded();

        public event PropertyChangedEventHandler PropertyChanged = delegate {};

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}