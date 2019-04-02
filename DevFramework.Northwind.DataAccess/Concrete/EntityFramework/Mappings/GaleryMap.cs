using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFramework.Northwind.Entities.Concrete;

namespace DevFramework.Northwind.DataAccess.Concrete.EntityFramework.Mappings
{
    class GaleryMap : EntityTypeConfiguration<Galery>
    {
        public GaleryMap()
        {
            ToTable(@"Galeries", @"dbo");
            HasKey(x => x.Id);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.ThumpImage).HasColumnName("ThumpImage");
            Property(x => x.Image).HasColumnName("Image");
        }
    }
}
