

namespace DegreeProject.DB.Models.Projects
{
    internal class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Cost { get; set; }
        public Estimate Estimate { get; set; }
        public Diagram Diagram { get; set; }
        public string ProjectStatus { get; set; }
        public ProjectOwner ProjectOwners { get; set; }
    }
}
