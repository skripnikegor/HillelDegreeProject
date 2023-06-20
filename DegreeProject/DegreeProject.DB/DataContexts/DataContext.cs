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
        internal DbSet<Diagram> Diagrams { get; set; }
        internal DbSet<Estimate> Estimates { get; set; }
        internal DbSet<Material> Materials { get; set; }
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<ProjectOwner> ProjectOwners { get; set; }
        internal DbSet<Work> Works { get; set; }
        internal DbSet<Standart> Standarts { get; set; }
        internal DbSet<WorksSettings> WorksSettings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=WIN-S6883EVAMDH\SQLEXPRESS;Initial Catalog=DegreeProject;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }

    }
}
