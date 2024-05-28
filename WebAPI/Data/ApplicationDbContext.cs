using Microsoft.EntityFrameworkCore;
using WebAPI.Models.Domain;

namespace WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInformation { get; set; }

    }
}
