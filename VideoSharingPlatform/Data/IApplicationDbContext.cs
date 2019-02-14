using Microsoft.EntityFrameworkCore;
using VideoSharingPlatform.Models;

namespace VideoSharingPlatform.Data
{
    public interface IApplicationDbContext
    {
        DbSet<FileData> FileDatas { get; set; }
    }
}
