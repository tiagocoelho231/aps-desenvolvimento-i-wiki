using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Data.Entity.TypeConfiguration;
using Wiki.Domain;

namespace Wiki.Data.Entity.Context
{
    public class WikiDbContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CharacterTypeConfiguration());
        }
    }
}
