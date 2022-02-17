using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    public class Cafe
    {
      

        [Key]
        public int Id { get; set; }
        //[ForeignKey("CafeId")]
        public List<BucketList> BucketList { get; set; }

        public string CafeName { get; set; }

        public string? Neighborhood { get; set; }   
        
        public string? WebsiteUrl { get; set; }


        public string? Address { get; set; }

        

        // an attraction can be on many diffrent bucket lists

        // public virtual CafeHours Hours {get; set;}

    }
}
