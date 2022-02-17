using stloumustdo.Models;

namespace stloumustdo.POCO
{
    public class UserCafeLists
    {

        public ICollection<Cafe> Cafes { get; set; }

        public ICollection<bool> HasCafe { get; set; } 

    }
}
