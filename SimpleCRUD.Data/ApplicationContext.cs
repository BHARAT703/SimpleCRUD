using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Model.Entities;

namespace SimpleCRUD.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options: options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                //item.DeleteBehavior = DeleteBehavior.Restrict;
            }

           // modelBuilder.Entity<RegulatorySchedule>()
           //.HasOne(s => s.DestinationStation)
           //.WithMany(s => s.RegulatoryScheduleDestinationStations)
           //.OnDelete(Microsoft.EntityFrameworkCore.Metadata.DeleteBehavior.Restrict);
        }
    }
}
