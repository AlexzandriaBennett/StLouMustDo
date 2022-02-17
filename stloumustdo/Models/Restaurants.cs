using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    public class Restaurants
    {


        [Key]
        public int Id { get; set; }
        //[ForeignKey("ResturauntId")]
        public List<BucketList> BucketList { get; set; }

        public string RestaurantName { get; set;}

        public string? RestaurantType { get; set; }

        public string? PriceRange { get; set;}

        public string? Neighborhood { get; set;}

        public string? WebsiteUrl { get; set;}

        public string? ResturauntAddress { get; set; }


        // an attraction can be on many diffrent bucket lists

        // public virtual ResturauntHours Hours {get; set;}
    }
}
