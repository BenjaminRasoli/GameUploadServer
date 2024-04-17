using GameUploadServer.Modals;
using Microsoft.EntityFrameworkCore;

namespace GameUploadServer.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions <AppDBContext>options) : base (options)
        {
            
        }


        public DbSet<ProjectData> UserProjects { get; set; }
        public DbSet<CommentData> UserComments { get; set; }
        public DbSet<UserData> UserDatas { get; set; }
    }
}
