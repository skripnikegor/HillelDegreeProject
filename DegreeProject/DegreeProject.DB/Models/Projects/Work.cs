
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace DegreeProject.DB.Models.Projects
{
    internal class Work : Material
    {
        public double Duration { get; set; }    
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        [ForeignKey("WorksSettings")]
        public int? WorksSettingsId { get; set; }
        public WorksSettings WorksSettings { get; set; }
        public IEnumerable<Diagram> Diagrams { get; set; }
    }
}
