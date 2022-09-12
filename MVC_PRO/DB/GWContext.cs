using Microsoft.EntityFrameworkCore;
using WebApi_DAL.Entities;

namespace WebApi_DAL
{
    public class GWContext : DbContext
    {
        public DbSet<Good> Goods { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<GoodOnWarehouse> GoodsOnWarehouses { get; set; }

        public GWContext(DbContextOptions<GWContext> contextOptions)
            : base(contextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodOnWarehouse>().HasKey(x => new { x.GoodId, x.WarehouseId });
        }
    }
}
