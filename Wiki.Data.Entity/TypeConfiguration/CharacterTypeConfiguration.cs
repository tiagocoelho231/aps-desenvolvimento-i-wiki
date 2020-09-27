using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wiki.Domain;
using Wiki.Generic.Entity;

namespace Wiki.Data.Entity.TypeConfiguration
{
    class CharacterTypeConfiguration : WikiEntityAbstractConfig<Character>
    {
        protected override void configureTableName()
        {
            ToTable("Character");
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

            Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Type");

            Property(p => p.Origin)
                .IsOptional()
                .HasMaxLength(50)
                .HasColumnName("Origin");
        }

        protected override void configurePrimaryKey()
        {
            HasKey(p => p.Id);
        }

        protected override void configureForeignKey()
        {
        }
    }
}
