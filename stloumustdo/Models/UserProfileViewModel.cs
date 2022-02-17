using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace stloumustdo.Models
{
    public class UserProfileViewModel
    {
        [Key]
        public int Id { get; set; }
        public string EmailAddress { get; set; }

        public string Name { get; set; }

        public string? ProfileImage { get; set; }

       public int BucketId { get; set; }    
       [ForeignKey("BucketId")]
       public virtual BucketList? BucketList { get; set; }

    }
}
