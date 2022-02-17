using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    
    public class BucketList
    {
        public BucketList()
        {
            Restaurants = new HashSet<Restaurants>();
            Cafes = new HashSet<Cafe>();
            Attractions = new HashSet<LocalAttraction>();
            Outdoors = new HashSet<StatewideOutdoors>();
        }
        [Key]
       
        public int BucketId { get; set; }
       
        public ICollection<Restaurants>? Restaurants { get; set; }
        
        
        public ICollection<StatewideOutdoors>? Outdoors { get; set; }
 
        public ICollection<Cafe>? Cafes { get; set; }

       
        public ICollection<LocalAttraction>? Attractions { get; set; }


      

       






    }
}
