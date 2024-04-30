using Microsoft.EntityFrameworkCore;
using Mining.Models;

namespace Mining.Data
{
    public class MiningContext : DbContext
    {
        public MiningContext(DbContextOptions<MiningContext> options) : base(options) { }
        public DbSet <User> Users { get; set; }
        public DbSet <Mining_Sites> Mining_Sites { get; set; }
        public DbSet <Employees> Employees { get; set; }
        public DbSet<Certifications> Certifications { get; set; }  
    }
}
