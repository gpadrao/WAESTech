using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WAES.Domain.Entities;

namespace WAES.Infra.Data.EntityConfig
{
    public class WAESImageMap : EntityTypeConfiguration<WAESImage>
    {
        public WAESImageMap()
        {
            HasKey(x => x.WAESImageId);
            Property(x => x.IdCompare).IsRequired();
            Property(x => x.ImageContent).IsRequired();
            Property(x => x.Side).IsRequired();

        }
    }
}
