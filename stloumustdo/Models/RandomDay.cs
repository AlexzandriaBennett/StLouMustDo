namespace stloumustdo.Models
{
    public class RandomDay
    { 
        public virtual Restaurants Restaurants { get; set; }

        public virtual Cafe Cafe { get; set; }

        public virtual LocalAttraction LocalAttraction { get; set; }

        public virtual StatewideOutdoors StatewideOutdoors { get; set;}
    }
}
