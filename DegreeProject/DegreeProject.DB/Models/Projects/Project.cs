

using System.ComponentModel.DataAnnotations.Schema;

namespace DegreeProject.DB.Models.Projects
{
    internal class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal Cost { get; set; }
        
        public IEnumerable<Estimate> Estimate { get; set; }
        public IEnumerable<Diagram> Diagram { get; set; }
        public string ProjectStatus { get; set; }
        [ForeignKey("ProjectOwners")]
        public int ProjectOwnersId { get; set; }
        public ProjectOwner ProjectOwners { get; set; }
    }
}
