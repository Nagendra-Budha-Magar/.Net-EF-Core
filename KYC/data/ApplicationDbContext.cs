using Microsoft.EntityFrameworkCore;
using KYC.Models.Entity;

namespace KYC.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
    }
}
