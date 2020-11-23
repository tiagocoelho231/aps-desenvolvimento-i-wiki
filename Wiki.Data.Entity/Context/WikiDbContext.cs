using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data.Entity.TypeConfiguration;
using Wiki.Business;

namespace Wiki.Data.Entity.Context
{
    public class WikiDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<CharacterType> CharacterTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CharacterTypeConfiguration());
            modelBuilder.Configurations.Add(new CharacterTypeTypeConfiguration());
        }
    }
}
