namespace Fapp.Data
{
    using Fapp.Data.Models;
	using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
	using Microsoft.EntityFrameworkCore;

    public class FappDbContext : IdentityDbContext<FappUser>, IFappDbContext
    {
        public FappDbContext(DbContextOptions<FappDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<FappUser>()
                .Property(f => f.Id)
                .ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}