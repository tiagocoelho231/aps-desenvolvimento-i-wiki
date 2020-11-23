using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Business;
using Wiki.Generic.Entity;

namespace Wiki.Data.Entity.TypeConfiguration
{
    public class CharacterTypeTypeConfiguration : WikiEntityAbstractConfig<CharacterType>
    {
        protected override void configureTableName()
        {
            ToTable("CharacterType");
        }

        protected override void configureTableFields()
        {
            Property(p => p.Id)
                .IsRequired()
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)
                .HasColumnName("Id");

            Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Name");

            Property(p => p.Description)
                    .IsOptional()
                    .HasMaxLength(200)
                    .HasColumnName("Description");
        }

        protected override void configurePrimaryKey()
        {
            HasKey(pk => pk.Id);
        }

        protected override void configureForeignKey()
        {
        }
    }
}
