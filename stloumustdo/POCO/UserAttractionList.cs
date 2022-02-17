using stloumustdo.Models;

namespace stloumustdo.POCO
{
    public class UserAttractionList
    {
        public ICollection<LocalAttraction> Attractions { get; set; }

        public ICollection<bool> HasAttraction { get; set; }
    }
}
