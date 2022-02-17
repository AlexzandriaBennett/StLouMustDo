using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    public class StatewideOutdoors
    {

        [Key]
        public int Id { get; set; }
        //[ForeignKey("OutdoorId")]
        //public virtual BucketList BucketList { get; set; }
        public List<BucketList> BucketList { get; set; }

        public string OutdoorName { get; set; }

        public string? DistanceFromSTL { get; set; }

        public string? OutdoorUrl { get; set; }

        public string? Address { get; set; }

        // an attraction can be on many diffrent bucket lists


        // public DateTime? When { get; set; }

    }
}
