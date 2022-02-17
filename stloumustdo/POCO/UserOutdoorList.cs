

using stloumustdo.Models;

namespace stloumustdo.POCO
{
    public class UserOutdoorList
    {
        public ICollection<StatewideOutdoors> Outdoors { get; set; }

        public ICollection<bool> HasOutdoorItem { get; set; }
    }
}
