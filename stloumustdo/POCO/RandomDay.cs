using stloumustdo.Models;

namespace stloumustdo.POCO
{
    public class RandomDay
    {
        public virtual Cafe Cafe { get; set; }

        public virtual Restaurants Restaurant { get; set; }

        public virtual StatewideOutdoors StatewideOutdoors { get; set;}

        public virtual LocalAttraction LocalAttraction { get; set; }
    }
}
