

using System.ComponentModel.DataAnnotations.Schema;

namespace DegreeProject.DB.Models.Projects
{
    internal class Diagram
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Work> Works { get; set; }
        [ForeignKey("ProjectBase")]
        public int? ProjectBaseId { get; set; }
        public ProjectBase? Project { get; set; }
    }
}
