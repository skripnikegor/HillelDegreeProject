using DegreeProject.DB.Models;
using Microsoft.EntityFrameworkCore;


namespace DegreeProject.DB.DataContexts
{
    public class DataContext : DbContext
    {

        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-S6883EVAMDH\SQLEXPRESS;Initial Catalog=DegreeProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
}
