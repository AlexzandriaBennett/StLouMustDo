using stloumustdo.Models;

namespace stloumustdo.POCO
{
    public class UserRestaurantList
    {
        public ICollection<Restaurants> Restaurants { get; set; }

        public ICollection<bool> HasRestaurant { get; set; }
    }
}
