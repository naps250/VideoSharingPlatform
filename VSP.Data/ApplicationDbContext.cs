using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoSharingPlatform.Models;

namespace VideoSharingPlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<FileData> FileDatas { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
