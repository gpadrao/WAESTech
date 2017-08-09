using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WAES.Domain.Entities;
using WAES.Infra.Data.EntityConfig;

namespace WAES.Infra.Data.Context
{
    public class WAESModelContext : BaseDbContext
    {
        public WAESModelContext() : base("WAESConnection")
        {
        }
        public IDbSet<WAESImage> Clientes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Conventions
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // ModelConfiguration
            modelBuilder.Configurations.Add(new WAESImageMap());
        }
    }
}
