using DataAccess.Entities;

using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CofeeShop> CofeeShops { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CofeeShop>()
                .HasData(new List<CofeeShop>
                {
                    new CofeeShop { Id = 1, Address="Bismarck, North Dakota", Name = "The Mighty Missouri Coffee"},
                    new CofeeShop { Id = 2, Address="Bismarck, North Dakota", Name = "Mighty Missouri Coffee Company"},
                    new CofeeShop { Id = 3, Address="St. Paul, Minnesota", Name = "Spyhouse Coffee"},
                    new CofeeShop { Id = 4, Address="Las Vegas, Nevada", Name = "Sambalatte"},
                    new CofeeShop { Id = 5, Address="Columbus, Ohio ", Name = "Fox in the Snow"},
                    new CofeeShop { Id = 6, Address="Salt Lake City, Utah", Name = "Three Pines Coffee"},
                    new CofeeShop { Id = 7, Address="NYC, New York", Name = "Abraco"},
                    new CofeeShop { Id = 8, Address="San Francisco ", Name = "Sightglass Coffee"},
                    new CofeeShop { Id = 9, Address="Naples, Florida", Name = "Narrative Coffee Roasters"},
                    new CofeeShop { Id = 10, Address="Honolulu, Hawaii", Name = "Morning Glass"},
                    new CofeeShop { Id = 11, Address="St. Cloud, Minnesota", Name = "Kinder Coffee Lab"},
                    new CofeeShop { Id = 12, Address="Chicago, Illinois", Name = "Sip & Savor"},
                    new CofeeShop { Id = 13, Address="Waynesville, North Carolina", Name = "Orchard Coffee"},
                    new CofeeShop { Id = 14, Address="Harrison, New Jersey", Name = "Coperaco"},
                    new CofeeShop { Id = 15, Address="San Diego, California", Name = "Communal Coffee"},
                    new CofeeShop { Id = 16, Address="Cleveland, Ohio", Name = "Rising Star Coffee Roasters"}
                });
        }
    }
}
