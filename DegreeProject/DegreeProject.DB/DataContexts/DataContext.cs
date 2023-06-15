using DegreeProject.DB.Models;
using DegreeProject.DB.Models.Projects;
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

        internal DbSet<Customer> Customers { get; set; }
        internal DbSet<UserProfile> UserProfiles { get; set; }
        internal DbSet<Standart> Standarts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-S6883EVAMDH\SQLEXPRESS;Initial Catalog=DegreeProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
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
