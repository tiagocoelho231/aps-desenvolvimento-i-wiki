using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wiki.Generic.Entity
{
    public abstract class WikiEntityAbstractConfig<T> : EntityTypeConfiguration<T> where T : class
    {
        public WikiEntityAbstractConfig()
        {
            configureTableName();
            configureTableFields();
            configurePrimaryKey();
            configureForeignKey();

        }

        protected abstract void configureTableName();
        protected abstract void configureTableFields();
        protected abstract void configurePrimaryKey();
        protected abstract void configureForeignKey();
    }
}
