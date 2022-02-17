using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using stloumustdo.Models;

namespace stloumustdo.Data
{
    public class stloumustdoContext : DbContext
    {
        public stloumustdoContext(DbContextOptions<stloumustdoContext> options)
            : base(options)
        {
        }

        public DbSet<stloumustdo.Models.Restaurants> Restaurants { get; set; }
        public DbSet<stloumustdo.Models.Cafe> Cafes { get; set; }

        public DbSet<stloumustdo.Models.LocalAttraction> LocalAttractions { get; set; }

        public DbSet<stloumustdo.Models.StatewideOutdoors> StatewideOutdoors { get; set; }

        public DbSet<stloumustdo.Models.BucketList> BucketList { get; set; }

        public DbSet<stloumustdo.Models.UserProfileViewModel> UserProfileViewModel { get; set; }

  





    }
}
