using DegreeProject.DB.Models.Projects;
using DegreeProject.DB.Models.Users;
using Microsoft.EntityFrameworkCore;


namespace DegreeProject.DB.DataContexts
{
    public class DataContext : DbContext
    {

        public DataContext()
        {
            
        }

        internal DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        internal DbSet<UserBase> Users { get; set; }
        internal DbSet<UserProfile> UserProfiles { get; set; }
        internal DbSet<Standart> Standarts { get; set; }
        internal DbSet<Material> Materials { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8MEAJAS;Initial Catalog=DegreeProject.Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBase>()
                .HasOne(c => c.UserProfile)
                .WithOne()
                .HasForeignKey<UserBase>(c => c.UserProfileId);
        }
    }
}
