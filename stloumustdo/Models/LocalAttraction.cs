using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    public class LocalAttraction
    {

        [Key]
        public int Id { get; set; }
        //[ForeignKey("AttractionId")]
        public List<BucketList> BucketList { get; set; }

        public string AttractionName { get; set; }


        public string? Neighborhood { get; set; }

        public string? AttractionUrl { get; set; }

        public string? Address { get; set; }

        // an attraction can be on many diffrent bucket lists



        //public string PriceRange { get; set; }

        //public string Tickets { get; set; }



        //public AttractionHours Hours {get; set;}
    }
}
