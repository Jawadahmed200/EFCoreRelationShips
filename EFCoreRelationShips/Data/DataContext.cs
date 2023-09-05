using EFCoreRelationShips.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EFCoreRelationShips.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {}

        public DbSet<Character> Characters { get; set; }
        public DbSet<BackPack> BackPacks{ get; set; }
        public DbSet<Weapon> Weapons{ get; set; }

    }
}
