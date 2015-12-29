using System.Threading.Tasks;

namespace RestaurantManager.Core
{
    public static  class RestaurantContextFactory
    {
        private static RestaurantContext _restaurantContext;

        public static async Task<RestaurantContext> GetRestaurantContext()
        {
            if (_restaurantContext == null)
            {
                _restaurantContext = new RestaurantContext();
                await _restaurantContext.InitializeContextAsync();
            }

            return _restaurantContext; 
        } 

    }
}
