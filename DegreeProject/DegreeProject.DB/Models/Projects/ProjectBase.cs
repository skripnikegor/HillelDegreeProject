
using DegreeProject.DB.Models.Users;


namespace DegreeProject.DB.Models.Projects
{
    internal class ProjectBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Cost { get; set; }
        
        public IEnumerable<Estimate> Estimates { get; set; }
        public IEnumerable<Diagram> Diagrams { get; set; }
        public string ProjectStatus { get; set; }
        public IEnumerable<UserBase>? Participants { get; set; }

        
       
    }
}
