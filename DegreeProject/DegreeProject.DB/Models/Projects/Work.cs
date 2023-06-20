
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace DegreeProject.DB.Models.Projects
{
    internal class Work : Material
    {
        public double Duration { get; set; }    
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public IEnumerable<Estimate> Estimates { get; set; }
        public IEnumerable<Diagram> Diagrams { get; set; }
        [ForeignKey("WorksSettings")]
        public int WorkSettingId { get; set; }
        public WorksSettings WorksSettings { get; set; }
    }
}
