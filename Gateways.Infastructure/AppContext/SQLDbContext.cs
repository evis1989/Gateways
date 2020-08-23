using Gateways.Data.Entities;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Gateways.Insfastructure.AppContext
{
    public class SQLDbContext : DbContext,IDbContext
    {
        protected virtual DbSet<PeripheralEntity> Peripherals { get; set; }
        protected virtual DbSet<GatewayEntity> Gateways { get; set; }

        public DbContext BaseDbContext => this;

        public SQLDbContext() : base("name=GatewayContext")
        {
      
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public async new Task<bool> SaveChangesAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
