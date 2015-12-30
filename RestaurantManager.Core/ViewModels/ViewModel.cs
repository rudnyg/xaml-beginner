using System.ComponentModel;
using System.Runtime.CompilerServices;
using RestaurantManager.Models.Annotations;

namespace RestaurantManager.Core.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        private bool _isLoading;
        private RestaurantContext _repository;

        public RestaurantContext Repository
        {
            get { return _repository; }
            private set
            {
                _repository = value; OnPropertyChanged();
            }
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set { _isLoading = value; OnPropertyChanged();}
        }

        protected ViewModel()
        {
            LoadData();
        }

        private async  void LoadData()
        {
            IsLoading = true;
            Repository = await RestaurantContextFactory.GetRestaurantContext();
            OnDataLoaded();
            IsLoading = false;
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