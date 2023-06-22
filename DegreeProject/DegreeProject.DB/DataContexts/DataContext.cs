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
        internal DbSet<Diagram> Diagrams { get; set; }
        internal DbSet<Estimate> Estimates { get; set; }
        internal DbSet<Material> Materials { get; set; }
        internal DbSet<Project> Projects { get; set; }
        internal DbSet<ProjectOwner> ProjectOwners { get; set; }
        internal DbSet<Work> Works { get; set; }
        internal DbSet<Standart> Standarts { get; set; }
<<<<<<< HEAD
        internal DbSet<UserBase> Users { get; set; }


=======
        internal DbSet<WorksSettings> WorksSettings { get; set; }
>>>>>>> 2bee67fcacdf4ecba80f4af64e3bf9d8dd2b9e7d

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-8MEAJAS;Initial Catalog=DegreeProject.Project;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=True");
        }

    }
}
