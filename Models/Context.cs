using Microsoft.EntityFrameworkCore;

namespace AspNetCoreFood.Models

{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-50T6SSM\\SQLEXPRESS; database=CoreFood;" +
                "integrated security=true;TrustServerCertificate=True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }

        public DbSet<Admin> Admins { get; set; }
    }
}
