using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VSP.Data.Models;

namespace VSP.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FileData> FileDatas { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
